using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.Interface;
using BookingMovieTickets.VIewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.DataAccess;
using MoviesBooking.Models;
using Website_Selling_Computer.Session;

namespace BookingMovieTickets.Controllers
{
    [Authorize]
    public class BookingTicketController : Controller
    {
        private readonly I_Cart _cartRepo;
        private readonly I_Ticket _ticketRepo;
        private readonly I_FilmRepository _FilmRepository;
        private readonly I_Schedule _ScheduleRepo;
        private readonly I_Receipt _ReceiptRepo;
        private readonly I_TheatreRoom _TheatreRoomRepo;
        private readonly I_FilmCategoryRepository _FilmCategoryRepository;
        private readonly BookingMovieTicketsDBContext _bookingMovieTicketsDBContext;
        public BookingTicketController(I_Cart cartRepo, I_Ticket ticketRepo, I_FilmRepository FilmRepository, I_Schedule scheduleRepo, I_Receipt receiptRepo,
            BookingMovieTicketsDBContext bookingMovieTicketsDBContext,I_TheatreRoom theatreRoomRepo, I_FilmCategoryRepository filmCategoryRepository )
        {
            _cartRepo = cartRepo;
            _ticketRepo = ticketRepo;
            _FilmRepository = FilmRepository;
            _ScheduleRepo = scheduleRepo;
            _ReceiptRepo = receiptRepo;
            _bookingMovieTicketsDBContext = bookingMovieTicketsDBContext;
            _TheatreRoomRepo = theatreRoomRepo;
            _FilmCategoryRepository = filmCategoryRepository;
        }

        // GET: BookingTicketController
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<TicketCart>("Cart");
            var cartDetail =_bookingMovieTicketsDBContext.TicketCartDetails.Include(p=>p.Ticket).ToList();
            ViewBag.Details=cartDetail;
            return View(cart);
        }
        public async Task<IActionResult> SelectSeats(int filmId, string Time)
        {
            var film = await _FilmRepository.GetByIdAsync(filmId);
            var schedule = _bookingMovieTicketsDBContext.FilmSchedules
                            .Where(fs => fs.FilmId == filmId)
                            .ToList();

            if(schedule.Any())
            {
                var firstSchedule = schedule.First();
                var room = await _bookingMovieTicketsDBContext.TheatreRooms
                                 .FirstOrDefaultAsync(room => room.TheatreRoomId == firstSchedule.TheatreRoomId);

                var availableSeats = _bookingMovieTicketsDBContext.Seats.Where(s=>s.TheatreRoomId == room.TheatreRoomId).ToList();

                var viewModel = new SeatVM
                {
                    Film = film,
                    Schedules = schedule,
                    TheatreRoom = room,
                    Seats = availableSeats
                };

                return View(viewModel);
            }
            return NotFound();
        }
    }
}
