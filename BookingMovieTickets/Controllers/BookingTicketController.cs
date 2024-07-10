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
            BookingMovieTicketsDBContext bookingMovieTicketsDBContext, I_TheatreRoom theatreRoomRepo, I_FilmCategoryRepository filmCategoryRepository, I_TicketDetail ticketDetail,
            IVnPayService vnPayService, I_ScheduleDescription scheduleDescription, UserManager<UserInfo> userManager,
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
                    ScheduleDescriptions = schedule.Select(s => s.ScheduleDescription),
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
            if (film != null && schedule != null && room != null && seat != null && scheduleDescription != null)
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
                    FilmScheduleDes = scheduleDescription.Description.ToString("hh\\:mm")
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
            /*var ticketVM = new TicketVM
            {
                TicketCart = cart,
                Receipt = new Receipt()
            };*/
            return View(cart);

        }
        [HttpPost]
        public async Task<IActionResult> BookTickets(Receipt receipt, string payment = "COD")
        {
            // Lấy giỏ hàng từ session
            var cart = HttpContext.Session.GetObjectFromJson<TicketCart>("Cart");
            if (cart == null || !cart.Items.Any())
            {
                return RedirectToAction("Index"); // Quay lại trang chủ nếu giỏ hàng trống
            }

            // Lấy thông tin người dùng hiện tại
            var user = await _userManager.GetUserAsync(User);

            if (payment == "Thanh toán bằng VnPay")
            {
                // Tạo mô hình yêu cầu thanh toán VnPay
                var vnPayModel = new VnPaymentRequestModel
                {
                    Price = (double)cart.Items.Sum(x => x.Price), // Tổng giá của các mục trong giỏ hàng
                    CreatedDate = DateTime.Now, // Ngày tạo yêu cầu
                    Description = $"{receipt.UserId}", // Mô tả chứa UserId
                    FullName = user.FullName, // Tên đầy đủ của người dùng
                    OrderId = new Random().Next(1000, 10000) // Tạo mã đơn hàng ngẫu nhiên
                };

                // Tạo danh sách các vé tạm thời
                var pendingTicketDetails = new List<TicketDetail>();

                foreach (var cartDetail in cart.Items)
                {
                    // Tạo và thêm TicketDetail entity
                    var ticketDetail = new TicketDetail
                    {
                        FilmId = cartDetail.FilmId,
                        FilmScheduleId = cartDetail.FilmScheduleId,
                        Price = cartDetail.Price,
                        SeatId = cartDetail.SeatId,
                        Ticket = new Ticket // Liên kết với một vé mới
                        {
                            PurchaseDate = DateTime.UtcNow
                        }
                    };
                    pendingTicketDetails.Add(ticketDetail);
                }

                // Tính tổng giá cho receipt
                decimal totalPrice = cart.Items.Sum(item => item.Price);

                // Tạo Receipt entity
                receipt.UserId = user.Id;
                receipt.PurchaseDate = DateTime.UtcNow;
                receipt.TotalPrice = totalPrice;
                receipt.IsPaid = false; // Đặt ban đầu là chưa thanh toán
                receipt.ReceiptDetails = new List<ReceiptDetail>();

                // Tạo URL thanh toán
                var paymentUrl = _vnPayService.CreatePaymentUrl(HttpContext, vnPayModel);

                // Lưu trữ thông tin tạm thời của chi tiết vé và biên lai vào Session 
                HttpContext.Session.SetObjectAsJson("PendingTicketDetails", pendingTicketDetails);
                HttpContext.Session.SetObjectAsJson("PendingReceipt", receipt);

                return Redirect(paymentUrl);
            }

            // Xử lý các phương thức thanh toán khác (nếu có)
            return View("PaymentFail");
        }


        [Authorize]
        public async Task<IActionResult> PaymentCallBack()
        {
            // Thực hiện thanh toán và lấy phản hồi từ VNPay
            var response = _vnPayService.PaymentExecute(Request.Query);
            if (response == null || response.VnPayResponseCode != "00")
            {
                TempData["Message"] = $"Lỗi thanh toán VNPay: {response.VnPayResponseCode}";
                return RedirectToAction("PaymentFail");
            }

            // Lấy lại thông tin từ Session
            var pendingTicketDetails = HttpContext.Session.GetObjectFromJson<List<TicketDetail>>("PendingTicketDetails");
            var pendingReceipt = HttpContext.Session.GetObjectFromJson<Receipt>("PendingReceipt");

            if (pendingTicketDetails == null || pendingReceipt == null)
            {
                TempData["Message"] = "Không thể xác thực thông tin thanh toán.";
                return RedirectToAction("PaymentFail");
            }

            // Bắt đầu giao dịch cơ sở dữ liệu
            using (var transaction = await _bookingMovieTicketsDBContext.Database.BeginTransactionAsync())
            {
                try
                {
                    // Thêm TicketDetail entities vào cơ sở dữ liệu
                    foreach (var ticketDetail in pendingTicketDetails)
                    {
                        // Thêm vé mới vào cơ sở dữ liệu
                        await _ticketRepo.AddAsync(ticketDetail.Ticket);
                        await _bookingMovieTicketsDBContext.SaveChangesAsync(); // Lưu để lấy TicketId

                        // Liên kết chi tiết vé với vé vừa được lưu
                        ticketDetail.TicketId = ticketDetail.Ticket.TicketId;
                        await _TicketDetailRepo.AddAsync(ticketDetail);

                        var seat = await _seatRepo.GetByIdAsync(ticketDetail.SeatId);
                        if (seat != null)
                        {
                            seat.IsBooked = true;
                            await _seatRepo.UpdateAsync(seat);
                        }
                    }

                    // Cập nhật Receipt entity
                    pendingReceipt.IsPaid = true;
                    pendingReceipt.ReceiptDetails = pendingTicketDetails.Select(td => new ReceiptDetail
                    {
                        TicketId = td.TicketId
                    }).ToList();

                    await _bookingMovieTicketsDBContext.Receipts.AddAsync(pendingReceipt);
                    await _bookingMovieTicketsDBContext.SaveChangesAsync();

                    // Commit transaction
                    await transaction.CommitAsync();

                    // Xóa thông tin tạm thời khỏi Session
                    HttpContext.Session.Remove("PendingTicketDetails");
                    HttpContext.Session.Remove("PendingReceipt");

                    // Thông báo thanh toán thành công
                    TempData["MessageSuccess"] = $"Thanh toán VNPAY thành công: {response.VnPayResponseCode}";
                    TempData["OrderId"] = response.OrderId;

                    return View("PaymentSuccess");
                }
                catch (Exception ex)
                {
                    // Rollback transaction nếu có lỗi
                    await transaction.RollbackAsync();
                    // Log the exception (logging code is not shown here)
                    TempData["Message"] = "Có lỗi xảy ra trong quá trình xử lý giao dịch.";
                    return RedirectToAction("PaymentFail");
                }
            }
        }

        public IActionResult RemoveFromCart(int filmID, int time, int seatID)
        {
            var cart =
           HttpContext.Session.GetObjectFromJson<TicketCart>("Cart");

            if (cart is not null)
            {

                cart.RemoveItem(filmID, time, seatID);

                // Lưu lại giỏ hàng vào Session sau khi đã xóa mục
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }
            return RedirectToAction("Index");
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


    }
}
