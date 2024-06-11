using BookingMovieTickets.DataAccess;
using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.EF;
using BookingMovieTickets.Repository.Interface;
using BookingMovieTickets.VIewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;


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
        private readonly I_ScheduleDescription _scheduleDescriptionRepo;
        private readonly ILogger<ScheduleController> _logger;
        public ScheduleController(BookingMovieTicketsDBContext context, I_Schedule scheduleRepository, I_TheatreRoom theatreRoomRepository, 
            I_Seat seatRepository, I_Theater theaterRepository, I_FilmRepository filmRepository, I_ScheduleDescription scheduleDescriptionRepo, ILogger<ScheduleController> logger)
        {
            _context = context;
            _ScheduleRepository = scheduleRepository;
            _TheatreRoomRepository = theatreRoomRepository;
            _SeatRepository = seatRepository;
            _TheaterRepository = theaterRepository;
            _FilmRepository = filmRepository;
            _scheduleDescriptionRepo = scheduleDescriptionRepo;
            _logger = logger;
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
            var film = await _context.Films
                .Include(f => f.FilmSchedules)
                    .ThenInclude(fs => fs.ScheduleDescription).
                    Include(f => f.FilmSchedules)
                    .ThenInclude(fs => fs.TheatreRoom)
                .ThenInclude(tr => tr.Theatre)
                .FirstOrDefaultAsync(f => f.FilmId == id);

            if (film == null)
            {
                return NotFound();
            }

            return View(film);
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

        public async Task<IActionResult> DisplaySchedule(int id)
        {
            var film= await _FilmRepository.GetByIdAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            var schedule = await _context.FilmSchedules.Include(fs => fs.Film)
            .Include(fs => fs.TheatreRoom)
            .Include(fs => fs.ScheduleDescription)
            .Where(fs => fs.FilmId == id)
            .ToListAsync();
            var vm = new EditScheduleVM
            {
                Film = film,
                FilmSchedules = schedule
            };
            return View(vm);
        }
        public async Task<IActionResult> Edit(int scheduleId,int filmId)
        {
            var scheduleDescriptions = await _scheduleDescriptionRepo.GetAllAsync();
            var schedule = await _ScheduleRepository.GetByIdAsync(scheduleId);
            if (schedule == null)
            {
                return NotFound();
            }
            ViewBag.scheduleDescription = new SelectList(scheduleDescriptions, "ScheduleDescriptionId", "Description");

            return View(schedule);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int scheduleId,int filmId, FilmSchedule filmSchedule)
        {
            var scheduleDescriptions = await _scheduleDescriptionRepo.GetAllAsync();
            if (scheduleId != filmSchedule.FilmScheduleId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                var existingSchedule = await _ScheduleRepository.GetByIdAsync(scheduleId);
                if (existingSchedule == null)
                {
                    return NotFound();
                }

                existingSchedule.ScheduleDescriptionId = filmSchedule.ScheduleDescriptionId;

                await _ScheduleRepository.UpdateAsync(existingSchedule);
                return RedirectToAction("DisplaySchedule", "Schedule", new { id = filmId });
            }
            ViewBag.scheduleDescription = new SelectList(scheduleDescriptions, "ScheduleDescriptionId", "Description");
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
        public async Task<IActionResult> AddSchedule() 
        {
            var scheduleDescriptions = await _scheduleDescriptionRepo.GetAllAsync();
            var rooms = await _TheatreRoomRepository.GetAllRoomAsync();
            var locations = await _TheaterRepository.GetAllAsync();

            var films = await _context.Films
            .Include(f => f.FilmSchedules).Where(f => !f.FilmSchedules.Any()).Where(f => f.StartTime <= DateTime.UtcNow)
            .ToListAsync();

            ViewBag.Movies =  new SelectList(films, "FilmId", "NameFilm");


            ViewBag.scheduleDescription = new SelectList(scheduleDescriptions, "ScheduleDescriptionId", "Description");

            ViewBag.Rooms = new SelectList(rooms, "TheatreRoomId", "RoomName");

            ViewBag.Theaters = new SelectList(locations, "TheatreId", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSchedule(FilmSchedule filmSchedule)
        {

            if (!ModelState.IsValid)
            {
                try
                {
                    await _ScheduleRepository.AddAsync(filmSchedule);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while adding the schedule. Please try again later.");
                    _logger.LogError(ex, "Error occurred while adding schedule.");
                }
            }

            var scheduleDescriptions = await _scheduleDescriptionRepo.GetAllAsync();
            var rooms = await _TheatreRoomRepository.GetAllRoomAsync();
            var locations = await _TheaterRepository.GetAllAsync();

            var films = await _context.Films
            .Include(f => f.FilmSchedules).Where(f => !f.FilmSchedules.Any()).Where(f=>f.StartTime<=DateTime.UtcNow)
            .ToListAsync();

            ViewBag.Movies = new SelectList(films, "FilmId", "NameFilm");

            ViewBag.scheduleDescription = new SelectList(scheduleDescriptions, "ScheduleDescriptionId", "Description");

            ViewBag.Rooms = new SelectList(rooms, "TheatreRoomId", "RoomName");

            ViewBag.Theaters = new SelectList(locations, "TheatreId", "Name");
            return View(filmSchedule);
        }

        public async Task<IActionResult> AddScheduleForSpecificFilm()
        {


            var scheduleDescriptions = await _scheduleDescriptionRepo.GetAllAsync();
            var rooms = await _TheatreRoomRepository.GetAllRoomAsync();
            var locations = await _TheaterRepository.GetAllAsync();

            var films = await _context.Films
            .Include(f => f.FilmSchedules).Where(f => f.FilmSchedules.Any()).Where(f => f.StartTime <= DateTime.UtcNow)
            .ToListAsync();
            ViewBag.Movies = new SelectList(films, "FilmId", "NameFilm");
            ViewBag.ScheduleDescription = new SelectList(scheduleDescriptions, "ScheduleDescriptionId", "Description");
            ViewBag.Rooms = new SelectList(rooms, "TheatreRoomId", "RoomName");
            ViewBag.Theaters = new SelectList(locations, "TheatreId", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddScheduleForSpecificFilm(FilmSchedule filmSchedule)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Check for existing schedule (same logic as before)
                    var existingSchedule = await _ScheduleRepository.GetScheduleByDetailsAsync(filmSchedule);
                    if (existingSchedule != null)
                    {
                        ModelState.AddModelError("", "This schedule already exists.");
                        return View(filmSchedule);
                    }

                    // Populate ViewBag with retrieved data (moved here)
                    var scheduleDescriptions = await _scheduleDescriptionRepo.GetAllAsync();
                    var rooms = await _TheatreRoomRepository.GetAllRoomAsync();
                    var locations = await _TheaterRepository.GetAllAsync();

                    var films = await _context.Films
                    .Include(f => f.FilmSchedules).Where(f => f.FilmSchedules.Any()).Where(f => f.StartTime <= DateTime.UtcNow)
                    .ToListAsync();
                    ViewBag.Movies = new SelectList(films, "FilmId", "NameFilm");

                    ViewBag.ScheduleDescription = new SelectList(scheduleDescriptions, "ScheduleDescriptionId", "Description");
                    ViewBag.Rooms = new SelectList(rooms, "TheatreRoomId", "RoomName");
                    ViewBag.Theaters = new SelectList(locations, "TheatreId", "Name");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while adding schedule.");
                    ModelState.AddModelError("", "An error occurred while adding the schedule. Please try again later.");
                }

                // Return view with populated ViewBag on validation errors
                return View(filmSchedule);
            }

            await _ScheduleRepository.AddAsync(filmSchedule);
            return RedirectToAction("Index", "Schedule");
        }

    }
}
