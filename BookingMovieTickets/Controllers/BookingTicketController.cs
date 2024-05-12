using BookingMovieTickets.Extensions;
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
        private readonly I_TicketDetail _TicketDetailRepo;
        private readonly I_FilmCategoryRepository _FilmCategoryRepository;
        private readonly BookingMovieTicketsDBContext _bookingMovieTicketsDBContext;
        public BookingTicketController(I_Cart cartRepo, I_Ticket ticketRepo, I_FilmRepository FilmRepository, I_Schedule scheduleRepo, I_Receipt receiptRepo,
            BookingMovieTicketsDBContext bookingMovieTicketsDBContext,I_TheatreRoom theatreRoomRepo, I_FilmCategoryRepository filmCategoryRepository,I_TicketDetail ticketDetail )
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
        }

        // GET: BookingTicketController
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<TicketCart>("Cart") ?? new TicketCart();
            return View(cart);
        }
        public async Task<IActionResult> SelectSeats(int filmId, int Time)
        {
            var film = await _FilmRepository.GetByIdAsync(filmId);
            var schedule = _bookingMovieTicketsDBContext.FilmSchedules
                            .Where(fs => fs.FilmId == filmId && fs.FilmScheduleId == Time)
                            .ToList();

            if (schedule.Any())
            {
                var firstSchedule = schedule.First();
                var room = await _bookingMovieTicketsDBContext.TheatreRooms
                                 .FirstOrDefaultAsync(room => room.TheatreRoomId == firstSchedule.TheatreRoomId);

                var availableSeats = _bookingMovieTicketsDBContext.Seats.Where(s => s.TheatreRoomId == room.TheatreRoomId).ToList();

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

        public async Task<IActionResult> AddToCart(int filmID, int time, int seatID)
        {
            var film = await _FilmRepository.GetByIdAsync(filmID);
            var schedule = await _ScheduleRepo.GetByIdAsync(time);
            var room = await _TheatreRoomRepo.GetByIdAsync(schedule.TheatreRoomId);
            var seat = await _bookingMovieTicketsDBContext.Seats.FindAsync(seatID);
            if (film != null)
            {
                var cartDetail = new TicketCartDetail
                {
                    FilmId = filmID,
                    FilmName = film.NameFilm,
                    PosterUrl = film.PosterUrl,
                    SeatId = seatID,
                    SeatNumber = seat.SeatNumber,
                    FilmScheduleId = time,
                    FilmScheduleDes = schedule.FilmScheduleDescription,
                    RoomName = room.RoomName,
                    Price =seat.SeatPrice
                };
                var cart = HttpContext.Session.GetObjectFromJson<TicketCart>("Cart") ?? new TicketCart();

                cart.AddItem(cartDetail);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
                return RedirectToAction("Index");
            }
            else
            {
                throw new FilmNotFoundException($"Film with ID {filmID} not found");
            }
        }
        public async Task<IActionResult> BookTickets()
        {
            var cart = HttpContext.Session.GetObjectFromJson<TicketCart>("Cart");
            if (cart == null || cart.Items.Count == 0)
            {
                // Handle case where cart is empty
                return RedirectToAction("Index", "CartTicket");
            }
            var ticket = new Ticket
            {
                PurchaseDate = DateTime.UtcNow,
                IsPaid = false
            };
            await _ticketRepo.AddAsync(ticket);
            // Iterate over items in the cart and transform them into tickets
            foreach (var cartDetail in cart.Items)
            {
                // Create a new ticket based on cart detail information
                var ticketDetail = new TicketDetail
                {
                    TicketId = ticket.TicketId,
                    FilmId = cartDetail.FilmId,
                    FilmScheduleId = cartDetail.FilmScheduleId, Price = cartDetail.Price,SeatId = cartDetail.SeatId
                };
                await _TicketDetailRepo.AddAsync(ticketDetail);
                // Add the ticket to your database (or any other persistence mechanism)
                
            }
            
            // Clear the cart after booking tickets
            HttpContext.Session.Remove("Cart");
            // Redirect to a page where the user can choose payment method
            return RedirectToAction("ChoosePaymentMethod");
        }

    }
}
