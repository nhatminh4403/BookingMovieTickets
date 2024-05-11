using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.Interface;
using BookingMovieTickets.VIewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.DataAccess;
using MoviesBooking.Models;
using Website_Selling_Computer.Session;

namespace BookingMovieTickets.Controllers
{
    public class CartTicketController : Controller
    {

        private readonly I_Cart _cartRepo;
        private readonly I_Ticket _ticketRepo;
        private readonly I_FilmRepository _FilmRepository;
        private readonly I_Schedule _ScheduleRepo;
        private readonly I_Receipt _ReceiptRepo;
        private readonly I_TheatreRoom _TheatreRoomRepo;
        private readonly I_FilmCategoryRepository _FilmCategoryRepository;
        private readonly BookingMovieTicketsDBContext _bookingMovieTicketsDBContext;
        public CartTicketController(I_Cart cartRepo, I_Ticket ticketRepo, I_FilmRepository FilmRepository, I_Schedule scheduleRepo, I_Receipt receiptRepo,
            BookingMovieTicketsDBContext bookingMovieTicketsDBContext, I_TheatreRoom theatreRoomRepo, I_FilmCategoryRepository filmCategoryRepository)
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
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<TicketCart>("Cart") ?? new TicketCart();
            var cartDetails = _bookingMovieTicketsDBContext.TicketCartDetails.Include(cd => cd.Ticket).ToList();
            ViewBag.CartDetails = cartDetails;
            return View(cart);
        }

        public async Task<IActionResult> AddToCart(int fimlID, int time, int seatID)
        {
            var film = await _FilmRepository.GetByIdAsync(fimlID);

            if (film != null)
            {
                var cartDetail = new TicketCartDetail
                {
                    FilmId = film.FilmId,
                    SeatId = seatID,
                    FilmScheduleId = time,
                };
                var cart = HttpContext.Session.GetObjectFromJson<TicketCart>("Cart") ?? new TicketCart();

                cart.AddItem(cartDetail);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
                return RedirectToAction("Index");
            }
            else
            {
               return NotFound();
            }
        }
    }
}
