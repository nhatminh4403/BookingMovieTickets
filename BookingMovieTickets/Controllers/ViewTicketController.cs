using BookingMovieTickets.DataAccess;
using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.Interface;
using BookingMovieTickets.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BookingMovieTickets.Controllers
{
    public class ViewTicketController : BaseController
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
        public ViewTicketController(I_Cart cartRepo, I_Ticket ticketRepo, I_FilmRepository filmRepository, I_Schedule scheduleRepo, I_Receipt receiptRepo, I_TheatreRoom theatreRoomRepo, I_TicketDetail ticketDetailRepo, IVnPayService vnPayService, I_Seat seatRepo, I_FilmCategoryRepository filmCategoryRepository, I_ScheduleDescription scheduleDescriptionRepo, BookingMovieTicketsDBContext bookingMovieTicketsDBContext, UserManager<UserInfo> userManager) : base(bookingMovieTicketsDBContext)
        {
            _cartRepo = cartRepo;
            _ticketRepo = ticketRepo;
            _FilmRepository = filmRepository;
            _ScheduleRepo = scheduleRepo;
            _ReceiptRepo = receiptRepo;
            _TheatreRoomRepo = theatreRoomRepo;
            _TicketDetailRepo = ticketDetailRepo;
            _vnPayService = vnPayService;
            _seatRepo = seatRepo;
            _FilmCategoryRepository = filmCategoryRepository;
            _ScheduleDescriptionRepo = scheduleDescriptionRepo;
            _bookingMovieTicketsDBContext = bookingMovieTicketsDBContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> showTickets()
        {
            var user = await _userManager.GetUserAsync(User);
            var receipts = await _bookingMovieTicketsDBContext.Receipts
                               .Include(r => r.ReceiptDetails)
                               .ThenInclude(rd => rd.Ticket)
                               .ThenInclude(t => t.TicketDetails)
                               .ThenInclude(td => td.Film)
                               .Include(r => r.ReceiptDetails)
                               .ThenInclude(rd => rd.Ticket)
                               .ThenInclude(t => t.TicketDetails)
                               .ThenInclude(td => td.Seat)
                               .Include(r => r.ReceiptDetails)
                               .ThenInclude(rd => rd.Ticket)
                               .ThenInclude(t => t.TicketDetails)
                               .ThenInclude(td => td.FilmSchedule)
                               .ThenInclude(fs => fs.ScheduleDescription)
                               .Where(r => r.UserId == user.Id).Distinct()
                               .ToListAsync();

            var tickets = receipts.SelectMany(r => r.ReceiptDetails.Select(rd => rd.Ticket)).ToList();

            return View(tickets);

        }
    }
}
