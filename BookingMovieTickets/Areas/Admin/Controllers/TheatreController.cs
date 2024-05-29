
using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.Interface;
using BookingMovieTickets.VIewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BookingMovieTickets.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = UserRole.Role_Admin)]
    public class TheatreController : Controller
    {
        private readonly I_Theater _TheaterRepository;
        private readonly I_TheatreRoom _TheaterRoomRepository;
        private readonly I_Seat _seatRepo;
        public TheatreController(I_Theater theaterRepository, I_TheatreRoom theaterRoomRepository, I_Seat seatRepo)
        {
            _TheaterRepository = theaterRepository;
            _TheaterRoomRepository = theaterRoomRepository;
            _seatRepo = seatRepo;
        }

        // GET: TheatreController
        public async Task<IActionResult> Index()
        {
            var theaters=  await _TheaterRepository.GetAllAsync();
            var rooms = await _TheaterRoomRepository.GetAllRoomAsync();
            var seat = await _seatRepo.GetAllSeatAsync();
            var location = new RoomVM
            {
                Theatres = theaters,
                TheatreRoom = rooms,
                Seats = seat
            };
            return View(location);
        }

        // GET: TheatreController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var details = await _TheaterRepository.GetByIdAsync(id);
            if(details == null)
            {
                return NotFound();
            }
            return View(details);
        }

        // GET: TheatreController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TheatreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
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

        // GET: TheatreController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        // POST: TheatreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
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

        // GET: TheatreController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }

        // POST: TheatreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
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
