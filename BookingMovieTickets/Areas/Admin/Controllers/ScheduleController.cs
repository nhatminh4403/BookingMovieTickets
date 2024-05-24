using BookingMovieTickets.Repository.Interface;
using BookingMovieTickets.VIewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly I_FilmRepository _FilmRepository;
        private readonly I_Theater _TheaterRepository; 
        public ScheduleController(BookingMovieTicketsDBContext context, I_Schedule scheduleRepository, I_TheatreRoom theatreRoomRepository, I_Seat seatRepository, I_Theater theaterRepository, I_FilmRepository filmRepository)
        {
            _context = context;
            _ScheduleRepository = scheduleRepository;
            _TheatreRoomRepository = theatreRoomRepository;
            _SeatRepository = seatRepository;
            _TheaterRepository = theaterRepository;
            _FilmRepository = filmRepository;
        }

        public async Task<IActionResult> Index()
        {
            var filmSchedules = await _context.FilmSchedules.Include(p=>p.Film).Include(p=>p.TheatreRoom).Include(p=>p.TheatreRoom.Theatre).ToListAsync();
            var films = await _context.Films
            .Include(f => f.FilmSchedules)
            .ThenInclude(fs => fs.TheatreRoom)
            .ThenInclude(tr => tr.Theatre)
            .ToListAsync();

            var filmsWithSchedules = films.Where(f => f.FilmSchedules.Any()).ToList();
            var filmsWithoutSchedules = films.Where(f => !f.FilmSchedules.Any()).ToList();
            var filmsWithoutSchedulesStartDateBeforeNow = filmsWithoutSchedules.Where(f=>f.StartTime > DateTime.UtcNow).ToList();
            var filmsWithoutSchedulesStartDateAfterNow = filmsWithoutSchedules.Where(f => f.StartTime<=DateTime.UtcNow).ToList();

            var filmIndexViewModel = new FilmScheduleVM
            {
                FilmsWithSchedules = filmsWithSchedules,
                FilmsWithoutSchedulesStartDateBeforeNow = filmsWithoutSchedulesStartDateBeforeNow,
                FilmsWithoutSchedulesStartDateAfterNow=filmsWithoutSchedulesStartDateAfterNow
            };

            return View(filmIndexViewModel);
        }
        public async Task<IActionResult> Details(int id)
        {
            var filmSchedule = await _FilmRepository.GetByIdAsync(id);
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
        public async Task<IActionResult> AddSchedule(FilmSchedule schedule, int movieId) // Use the Showtime model as the parameter
        {
            //showtime.MovieId = movieId;
            var movies = await _FilmRepository.GetAllShowAsync(movieId);
            ViewBag.Movies = new SelectList(movies, "FilmId", "NameFilm");

/*            var screentimes = await _screentimeRepo.GetAllAsync();
            ViewBag.Screentimes = new SelectList(screentimes, "ScreenTimeId", "ScreenTime");*/

            var rooms = await _TheatreRoomRepository.GetAllRoomAsync();
            ViewBag.Rooms = new SelectList(rooms, "TheatreRoomId", "RoomName");

            var location = await _TheaterRepository.GetAllAsync();
            ViewBag.Theaters = new SelectList(location, "TheatreId", "Name");

            return View(schedule); // Re-render the view with populated showtime object (for validation errors)
        }
        [HttpPost]
        public async Task<IActionResult> AddSchedule(FilmSchedule schedule, int movieId, string roomId)
        {
            //var movie = await _movieRepo.GetByIdAsync(movieId);
            //var room = await _roomRepo.GetByIdAsync(roomId);
            if (ModelState.IsValid)
            {
                await _ScheduleRepository.AddAsync(schedule);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Nếu ModelState không hợp lệ, hiển thị form với dữ liệu đã nhập
                var movies = await _FilmRepository.GetAllShowAsync(movieId);
                ViewBag.Movies = new SelectList(movies, "FilmId", "NameFilm");

                /*            var screentimes = await _screentimeRepo.GetAllAsync();
                            ViewBag.Screentimes = new SelectList(screentimes, "ScreenTimeId", "ScreenTime");*/

                var rooms = await _TheatreRoomRepository.GetAllRoomAsync();
                ViewBag.Rooms = new SelectList(rooms, "TheatreRoomId", "RoomName");

                var location = await _TheaterRepository.GetAllAsync();
                ViewBag.Theaters = new SelectList(location, "TheatreId", "Name");

                return View(schedule);
            }

        }
    }
}
