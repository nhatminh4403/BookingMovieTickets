
using BookingMovieTickets.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using MoviesBooking.DataAccess;

namespace BookingMovieTickets.Areas.Admin.Controllers
{
    public class SeatController : Controller
    {
        private readonly I_TheatreRoom _TheatreRoomRepository;
        private readonly I_Seat _SeatRepo;
        private readonly BookingMovieTicketsDBContext _dbContext;
        public SeatController(I_TheatreRoom theatreRoomRepository, I_Seat seatRepo, BookingMovieTicketsDBContext dbContext)
        {
            _TheatreRoomRepository = theatreRoomRepository;
            _SeatRepo = seatRepo;
            _dbContext = dbContext;
        }

        // GET: SeatController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SeatController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var rooms = await _TheatreRoomRepository.GetByIdAsync(id);
            return View();
        }

        // GET: SeatController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SeatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SeatController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SeatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SeatController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SeatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
