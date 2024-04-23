using Microsoft.AspNetCore.Mvc;

namespace BookingMovieTickets.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
