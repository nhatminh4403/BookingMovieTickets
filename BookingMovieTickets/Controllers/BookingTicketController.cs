using BookingMovieTickets.Extensions;
using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.Interface;
using BookingMovieTickets.Services;
using BookingMovieTickets.VIewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


using BookingMovieTickets.Session;
using BookingMovieTickets.Helper;
using BookingMovieTickets.DataAccess;
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
        private readonly I_Seat _seatRepo;
        private readonly I_FilmCategoryRepository _FilmCategoryRepository;
        private readonly I_ScheduleDescription _ScheduleDescriptionRepo;
        private readonly BookingMovieTicketsDBContext _bookingMovieTicketsDBContext;
        private readonly UserManager<UserInfo> _userManager;

        public BookingTicketController(I_Cart cartRepo, I_Ticket ticketRepo, I_FilmRepository FilmRepository, I_Schedule scheduleRepo, I_Receipt receiptRepo,
            BookingMovieTicketsDBContext bookingMovieTicketsDBContext,I_TheatreRoom theatreRoomRepo, I_FilmCategoryRepository filmCategoryRepository,I_TicketDetail ticketDetail, 
            IVnPayService vnPayService,I_ScheduleDescription scheduleDescription, UserManager<UserInfo> userManager,
            I_Seat seatRepo)
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
            _seatRepo = seatRepo;
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

            HttpContext.Session.Remove("Cart");
            await HttpContext.Session.CommitAsync();


            if (schedule.Any())
            {
                var firstSchedule = schedule.First();
                var room = await _bookingMovieTicketsDBContext.TheatreRooms
                                 .FirstOrDefaultAsync(room => room.TheatreRoomId == firstSchedule.TheatreRoomId);
                var scheduleDescription = await _bookingMovieTicketsDBContext.ScheduleDescriptions
                     .FirstAsync(fs => fs.ScheduleDescriptionId == descriptionId);
                var availableSeats = await _bookingMovieTicketsDBContext.Seats.Where(s => s.TheatreRoomId == room.TheatreRoomId).ToListAsync();

                var viewModel = new SeatVM
                {
                    Film = film,
                    Schedules = schedule,
                    TheatreRoom = room,
                    Seats = availableSeats,
                    ScheduleId = Time,
                    ScheduleDescriptionId = descriptionId,
                    ScheduleDescriptions = schedule.Select(s=>s.ScheduleDescription),
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
            if (film != null && schedule != null && room !=null && seat != null && scheduleDescription !=null)
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
                    FilmScheduleDescriptionID = descriptionId,
                    FilmScheduleDes= scheduleDescription.Description.ToString("hh\\:mm")
                };
                var cart = HttpContext.Session.GetObjectFromJson<TicketCart>("Cart") ?? new TicketCart();

                cart.AddOrRemoveItem(cartDetail);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
                return RedirectToAction("Index");
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

            /*if (!cart.Items.Any() || cart == null)
            {
                // Handle case where cart is empty
                return RedirectToAction("Index");
            }*/
            var ticketVM = new TicketVM
            {
                TicketCart = cart,
                Receipt = new Receipt()
            };
            return View(cart);

        }

        [HttpPost]
        public async Task<IActionResult> BookTickets(Receipt receipt,string payment = "COD")
        {
            var cart = HttpContext.Session.GetObjectFromJson<TicketCart>("Cart");
            if (cart == null || !cart.Items.Any())
            {
                return RedirectToAction("Index");
            }

            var user = await _userManager.GetUserAsync(User);
            if (payment == "Thanh toán bằng VnPay")
            {
                var vnPayModel = new VnPaymentRequestModel
                {
                    Price = (double)cart.Items.Sum(x => x.Price),
                    CreatedDate = DateTime.Now,
                    Description = $"{receipt.UserId}",
                    FullName = user.FullName,
                    OrderId = new Random().Next(1000, 10000)
                };
                using (var transaction = await _bookingMovieTicketsDBContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        // Create and add the Ticket entity
                        var ticket = new Ticket
                        {
                            PurchaseDate = DateTime.UtcNow,
                            IsPaid = false
                        };
                        await _ticketRepo.AddAsync(ticket);
                        await _bookingMovieTicketsDBContext.SaveChangesAsync(); // Save to get the TicketId

                        // Create and add the TicketDetail entities
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

                            var seat = await _seatRepo.GetByIdAsync(cartDetail.SeatId);
                            if (seat != null)
                            {
                                seat.IsBooked = true;
                                await _seatRepo.UpdateAsync(seat);
                            }
                        }

                        // Calculate the total price for the receipt
                        decimal totalPrice = cart.Items.Sum(item => item.Price);

                        // Create and add the Receipt entity
                        receipt.UserId = user.Id;
                        receipt.PurchaseDate = DateTime.UtcNow;
                        receipt.TotalPrice = totalPrice; // Set the calculated total price
                        receipt.ReceiptDetails = cart.Items.Select(i => new ReceiptDetail
                        {
                            ReceiptId = receipt.ReceiptId,
                            TicketId = ticket.TicketId
                        }).ToList();

                        await _bookingMovieTicketsDBContext.Receipts.AddAsync(receipt);

                        // Save all changes within the transaction
                        await _bookingMovieTicketsDBContext.SaveChangesAsync();
                        await transaction.CommitAsync();

                        // Clear the cart after booking tickets
                        HttpContext.Session.Remove("Cart");
                        await HttpContext.Session.CommitAsync();
                        return Redirect(_vnPayService.CreatePaymentUrl(HttpContext, vnPayModel));

                    }
                    catch (Exception ex)
                    {
                        // Rollback transaction if any error occurs
                        await transaction.RollbackAsync();
                        // Log the exception (logging code is not shown here)
                        return View(nameof(Index));
                    }
                }
            }
            return View("PaymentFail");

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
            var response = _vnPayService.PaymentExecute(Request.Query);
            if (response == null || response.VnPayResponseCode != "00")

            {
                TempData["Message"] = $"Lỗi thanh toán VNPay: {response.VnPayResponseCode}";
                return RedirectToAction("PaymentFail");
            }
            TempData["MessageSucess"] = $"Thanh toán VNPAY thành công: {response.VnPayResponseCode}";
            //  TempData["Message"] = $"Thanh toán VNPAY thành công: {response.VnPayResponseCode}";

            TempData["OrderId"] = response.OrderId;

            return View("PaymentSuccess");
        }
        [Authorize]
        public IActionResult PaymentFail()
        {
            return View();
        }
        [Authorize]
        public IActionResult PaymentSuccess()
        {
            return View();
        }

        public async Task<IActionResult> showTickets()
        {
            var tickets = await _ticketRepo.GetAllAsync();

            return View(tickets);
        }

    }
}
