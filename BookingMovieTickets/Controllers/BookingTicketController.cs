using BookingMovieTickets.Extensions;
using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.Interface;
using BookingMovieTickets.Services;
using BookingMovieTickets.VIewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.DataAccess;
using MoviesBooking.Models;
using Website_Selling_Computer.Session;

namespace BookingMovieTickets.Controllers
{
    [Authorize]
    public class BookingTicketController : BaseController
    {
        private readonly I_Cart _cartRepo;
        private readonly I_Ticket _ticketRepo;
        private readonly I_FilmRepository _FilmRepository;
        private readonly I_Schedule _ScheduleRepo;
        private readonly I_Receipt _ReceiptRepo;
        private readonly I_TheatreRoom _TheatreRoomRepo;
        private readonly I_TicketDetail _TicketDetailRepo;
        private readonly IVnPayService _vnPayService;
        private readonly I_FilmCategoryRepository _FilmCategoryRepository;
        private readonly I_ScheduleDescription _ScheduleDescriptionRepo;
        private readonly BookingMovieTicketsDBContext _bookingMovieTicketsDBContext;
        private readonly UserManager<UserInfo> _userManager;

        public BookingTicketController(I_Cart cartRepo, I_Ticket ticketRepo, I_FilmRepository FilmRepository, I_Schedule scheduleRepo, I_Receipt receiptRepo,
            BookingMovieTicketsDBContext bookingMovieTicketsDBContext,I_TheatreRoom theatreRoomRepo, I_FilmCategoryRepository filmCategoryRepository,I_TicketDetail ticketDetail, 
            IVnPayService vnPayService,I_ScheduleDescription scheduleDescription, UserManager<UserInfo> userManager)
            : base(bookingMovieTicketsDBContext)
        {
            _cartRepo = cartRepo;
            _ticketRepo = ticketRepo;
            _FilmRepository = FilmRepository;
            _ScheduleRepo = scheduleRepo;
            _ReceiptRepo = receiptRepo;
            _bookingMovieTicketsDBContext = bookingMovieTicketsDBContext;
            _TheatreRoomRepo = theatreRoomRepo;
            _FilmCategoryRepository = filmCategoryRepository;
            _TicketDetailRepo = ticketDetail;
            _userManager = userManager;
            _vnPayService = vnPayService;
            _ScheduleDescriptionRepo = scheduleDescription;
        }

        // GET: BookingTicketController
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<TicketCart>("Cart") ?? new TicketCart();
            return View(cart);
        }
        public async Task<IActionResult> SelectSeats(int filmId, int Time, int descriptionId)
        {
            var film = await _FilmRepository.GetByIdAsync(filmId);
            var schedule = await _bookingMovieTicketsDBContext.FilmSchedules
                            .Include(fs => fs.TheatreRoom)
                             .Include(fs => fs.ScheduleDescription)
                            .Where(fs => fs.FilmId == filmId && fs.FilmScheduleId == Time)
                            .ToListAsync();
            var scheduleDescription = await _bookingMovieTicketsDBContext.ScheduleDescriptions
                        .Where(fs =>  fs.ScheduleDescriptionId == descriptionId).ToListAsync();

            var categories = await _FilmCategoryRepository.GetAllAsync();
            if (schedule.Any())
            {
                var firstSchedule = schedule.First();
                var room = await _bookingMovieTicketsDBContext.TheatreRooms
                                 .FirstOrDefaultAsync(room => room.TheatreRoomId == firstSchedule.TheatreRoomId);

                var availableSeats = await _bookingMovieTicketsDBContext.Seats.Where(s => s.TheatreRoomId == room.TheatreRoomId).ToListAsync();

                var viewModel = new SeatVM
                {
                    Film = film,
                    Schedules = schedule,
                    TheatreRoom = room,
                    Seats = availableSeats,
                    ScheduleId = Time,
                    ScheduleDescriptions = scheduleDescription,
                    ScheduleDescriptionId = descriptionId
                };
                ViewData["SeatVM"] = viewModel;
                return View(viewModel);
            }
            return NotFound();
        }
        
        public async Task<IActionResult> AddToCart(int filmID, int time, int seatID, int descriptionId)
        {
            var film = await _FilmRepository.GetByIdAsync(filmID);
            var schedule = await _ScheduleRepo.GetByIdAsync(time);
            var room = await _TheatreRoomRepo.GetByIdAsync(schedule.TheatreRoomId);
            var seat = await _bookingMovieTicketsDBContext.Seats.FindAsync(seatID);
            var scheduleDescription = await _ScheduleDescriptionRepo.GetByIdAsync(descriptionId);
            if (film != null && schedule != null && room !=null && seat != null)
            {
                var cartDetail = new TicketCartDetail
                {
                    FilmId = filmID,
                    FilmName = film.NameFilm,
                    PosterUrl = film.PosterUrl,
                    SeatId = seatID,
                    SeatNumber = seat.SeatNumber,
                    FilmScheduleId = time,
                    RoomName = room.RoomName,
                    Price = seat.SeatPrice,
                    FilmScheduleDes= scheduleDescription.Description.ToString("hh\\:mm")
                };
                var cart = HttpContext.Session.GetObjectFromJson<TicketCart>("Cart") ?? new TicketCart();

                cart.AddOrRemoveItem(cartDetail);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
                return Json(new { success = true, message = "Seat added to cart successfully!" });
            }
            else
            {
                throw new FilmNotFoundException($"Film with ID {filmID} not found");
            }
        }


        [Authorize]
        public async Task<IActionResult> BookTickets()
        {
            var cart = HttpContext.Session.GetObjectFromJson<TicketCart>("Cart");

            if (!cart.Items.Any())
            {
                // Handle case where cart is empty
                return RedirectToAction("Index", "CartTicket");
            }
            var ticketVM = new TicketVM
            {
                TicketCart = cart,
                Receipt = new Receipt()
            };
            return View(ticketVM);

        }

        [HttpPost]
        public async Task<IActionResult> BookTickets(Receipt receipt, string payment)
        {
            var cart = HttpContext.Session.GetObjectFromJson<TicketCart>("Cart");
            if(cart == null)
            {
                return RedirectToAction("Index");
            }
            var user = await _userManager.GetUserAsync(User);
            if (payment == "thanh toán")
            {
                var vnPayModel = new VnPaymentRequestModel
                {
                    SeatPrice = cart.Items.Sum(x => x.Price),
                    CreatedDate = DateTime.Now,
                    Desc = $"{receipt.UserId}",
                    FullName = receipt.User.FirstName,
                    ReceiptId = new Random().Next(1000, 10000)
                };

                using (var transaction = await _bookingMovieTicketsDBContext.Database.BeginTransactionAsync())
                {
                    
                    var ticket = new Ticket
                    {
                        PurchaseDate = DateTime.UtcNow,
                        IsPaid = false
                        
                    };
                    await _ticketRepo.AddAsync(ticket);
                    foreach (var cartDetail in cart.Items)
                    {
                        var ticketDetail = new TicketDetail
                        {
                            TicketId = ticket.TicketId,
                            FilmId = cartDetail.FilmId,
                            FilmScheduleId = cartDetail.FilmScheduleId,
                            Price = cartDetail.Price,
                            SeatId = cartDetail.SeatId
                        };
                        await _TicketDetailRepo.AddAsync(ticketDetail);

                    }
                    receipt.UserId = user.Id;
                    receipt.PurchaseDate = DateTime.UtcNow;
                    receipt.TotalPrice = receipt.CalculateTotalPrice();
                    receipt.ReceiptDetails = cart.Items.Select(i => new ReceiptDetail
                    {
                        TicketId = i.TicketId
                    }).ToList();

                    await _bookingMovieTicketsDBContext.Receipts.AddAsync(receipt);
                    await _bookingMovieTicketsDBContext.SaveChangesAsync();
                    // Clear the cart after booking tickets
                    HttpContext.Session.Remove("Cart");
                    // Redirect to a page where the user can choose payment method

                }

                return Redirect(_vnPayService.CreatePaymentUrl(HttpContext, vnPayModel));
            }
            return View(nameof(Index));
        }

        public IActionResult RemoveFromCart(int filmID, int time, int seatID)
        {
            var cart =
           HttpContext.Session.GetObjectFromJson<TicketCart>("Cart");

            if (cart is not null)
            {

                cart.RemoveItem(filmID,time,seatID);

                // Lưu lại giỏ hàng vào Session sau khi đã xóa mục
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult PaymentCallBack()
        {
            var cart = HttpContext.Session.GetObjectFromJson<TicketCart>("Cart");

            var response = _vnPayService.PaymentExecute(Request.Query);
            if (response == null || response.VnPayResponseCode != "00")

            {
                TempData["Message"] = $"Lỗi thanh toán VNPay: {response.VnPayResponseCode}";
                return RedirectToAction("PaymentFail");
            }
            TempData["MessageSucess"] = $"Thanh toán VNPAY thành công: {response.VnPayResponseCode}";
            //  TempData["Message"] = $"Thanh toán VNPAY thành công: {response.VnPayResponseCode}";

            TempData["OrderId"] = response.ReceiptId;

            return View("SucessfulOrder");
        }
    }
}
