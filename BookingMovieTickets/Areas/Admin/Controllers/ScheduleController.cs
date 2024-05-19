using BookingMovieTickets.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.DataAccess;
using MoviesBooking.Models;

namespace BookingMovieTickets.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = UserRole.Role_Admin)]
    public class ScheduleController : Controller
    {
        // GET: ScheduleController
        private readonly BookingMovieTicketsDBContext _context;
        private readonly I_Schedule _ScheduleRepository;
        private readonly I_TheatreRoom _TheatreRoomRepository;
        private readonly I_Seat _SeatRepository;
        private readonly I_Theater _TheaterRepository; 
        public ScheduleController(BookingMovieTicketsDBContext context, I_Schedule scheduleRepository, I_TheatreRoom theatreRoomRepository, I_Seat seatRepository, I_Theater theaterRepository)
        {
            _context = context;
            _ScheduleRepository = scheduleRepository;
            _TheatreRoomRepository = theatreRoomRepository;
            _SeatRepository = seatRepository;
            _TheaterRepository = theaterRepository;
        }

        public async Task<IActionResult> Index()
        {
            var filmSchedules = await _ScheduleRepository.GetAllAsync();
            return View(filmSchedules);
        }
        public async Task<IActionResult> Details(int id)
        {
            var filmSchedule = await _ScheduleRepository.GetByIdAsync(id);
            if (filmSchedule == null)
            {
                return NotFound();
            }
            return View(filmSchedule);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FilmSchedule filmSchedule)
        {
            if (ModelState.IsValid)
            {
                await _ScheduleRepository.AddAsync(filmSchedule);
                return RedirectToAction(nameof(Index));
            }
            return View(filmSchedule);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var filmSchedule = await _ScheduleRepository.GetByIdAsync(id);
            if (filmSchedule == null)
            {
                return NotFound();
            }
            return View(filmSchedule);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FilmSchedule filmSchedule)
        {
            if (id != filmSchedule.FilmScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _ScheduleRepository.UpdateAsync(filmSchedule);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmScheduleExists(filmSchedule.FilmScheduleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(filmSchedule);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var filmSchedule = await _ScheduleRepository.GetByIdAsync(id);
            if (filmSchedule == null)
            {
                return NotFound();
            }
            return View(filmSchedule);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ScheduleRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool FilmScheduleExists(int id)
        {
            return _ScheduleRepository.GetByIdAsync(id) != null;
        }
    }
}
