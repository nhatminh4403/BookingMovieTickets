using BookingMovieTickets.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookingMovieTickets.Controllers
{
    public class SeatsController : Controller
    {

        private readonly ISeatService _seatService;

        public SeatsController(ISeatService seatService)
        {
            _seatService = seatService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("reset")]
        public IActionResult ResetSeats()
        {
            _seatService.ResetSeats();
            return Ok(new { message = "Seats have been reset" });
        }
    }
}
