
using BookingMovieTickets.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesBooking.DataAccess;
using MoviesBooking.Models;

namespace BookingMovieTickets.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = UserRole.Role_Admin)]
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
        public async Task<IActionResult> Index()
        {
            var seats = await _SeatRepo.GetAllSeatAsync();
            return View(seats);
        }

        // GET: SeatController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var seats = await _SeatRepo.GetByIdAsync(id);
            return View(seats);
        }

        // GET: SeatController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SeatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seat seat)
        {
            if (ModelState.IsValid)
            {
                await _SeatRepo.AddAsync(seat);
                return RedirectToAction("Index", "Manager", new { area = "Admin" });
            }
            return View(seat);
        }

        // GET: SeatController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var seat = await _SeatRepo.GetByIdAsync(id);
            if (seat == null)
            {
                return NotFound();
            }
            return View(seat);
        }

        // POST: SeatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seat seat)
        {
            if (id != seat.SeatId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _SeatRepo.UpdateAsync(seat);
                return RedirectToAction("Index", "Manager", new { area = "Admin" });
            }
            return View();
        }

        // GET: SeatController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var seat = await _SeatRepo.GetByIdAsync(id);
            if (seat == null)
            {
                return NotFound();
            }
            return View(seat);
        }

        // POST: SeatController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seat = await _SeatRepo.GetByIdAsync(id);
            if (seat == null)
            {
                await _SeatRepo.DeleteAsync(id);
            }
            return RedirectToAction("Index", "Manager", new { area = "Admin" });
        }
    }
}
