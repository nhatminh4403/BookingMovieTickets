using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.Interface;
using BookingMovieTickets.VIewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.DataAccess;
using MoviesBooking.Models;
using System.Diagnostics;

namespace BookingMovieTickets.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<UserInfo> _userManager;
        private readonly I_FilmCategoryRepository _filmCategoryRepository;
        private readonly I_FilmRepository _filmRepository;
        private readonly I_Seat _seatRepo;
        private readonly BookingMovieTicketsDBContext _dbContext;
        private readonly I_PremiereTime _premiereTimeRepo;
        private readonly I_Schedule _scheduleRepo;
        private readonly I_TheatreRoom _theatreRoomRepo;
        private readonly I_Theater _TheaterRepo;

        public HomeController(ILogger<HomeController> logger, UserManager<UserInfo> userManager, I_FilmCategoryRepository filmCategoryRepository, I_FilmRepository filmRepository,
            I_PremiereTime premiereTime, I_Seat seatRepo, I_Schedule scheduleRepo, I_TheatreRoom theatreRoomRepo, I_Theater theaterRepo, BookingMovieTicketsDBContext dbContext)
        {
            _logger = logger;
            _userManager = userManager;
            _filmRepository = filmRepository;
            _seatRepo = seatRepo;
            _scheduleRepo = scheduleRepo;
            _filmCategoryRepository = filmCategoryRepository;
            _premiereTimeRepo = premiereTime;
            _theatreRoomRepo = theatreRoomRepo;
            _TheaterRepo = theaterRepo;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var films = await _filmRepository.GetAllAsync();
            var categories = await _filmCategoryRepository.GetAllAsync();
            var seats = await _seatRepo.GetAllSeatAsync();
            var schedules = await _scheduleRepo.GetAllAsync();
            var premiere = await _premiereTimeRepo.GetAllAsync();
            var rooms = await _theatreRoomRepo.GetAllRoomAsync();
            var theaters = await _TheaterRepo.GetAllAsync();
            var filmVM = new FilmVM
            {
                Films = films,
                FilmCategories = categories,
                Seats = seats,
                FilmSchedules = schedules,
                PremiereTime = premiere,
                TheatreRooms = rooms,
                Theatres = theaters
            };

            ViewData["LayoutModel"] = filmVM;
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    if (await _userManager.IsInRoleAsync(user, "Admin"))
                    {
                        return RedirectToAction("Index", "Manager", new { area = "Admin" });
                    }
                }

            }
            return View(filmVM);
        }

        public async Task<IActionResult> FilmDetailView(int id)
        {
            var film = await _dbContext.Films.Include(p => p.FilmCategory).Include(p => p.PremiereTimes).Include(f => f.FilmSchedules).ThenInclude(fs => fs.TheatreRoom)
                                             .ThenInclude(tr => tr.Theatre)
                                     .FirstOrDefaultAsync(f => f.FilmId == id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }
        public async Task<IActionResult> BookingSeat(int idFilm, string ScheduleFilm)
        {

            var filmSchedule = await _scheduleRepo.GetAllAsync();

            foreach (var item in filmSchedule)
            {
                if (item.FilmId == idFilm && item.FilmScheduleDescription == ScheduleFilm)
                {

                    var room = await _theatreRoomRepo.GetByIdAsync(item.TheatreRoomId);
                    return View(room);
                }
            }

            return NotFound();
        }

        public async Task<IActionResult> AllFilm()
        {
            var film = await _filmRepository.GetAllAsync();

            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }


        public async Task<IActionResult> SortFilmsByCategories(int id)
        {

            var categoriesFilm = await _filmRepository.FindByCategoriesAsync(id);

            var categoryID = await _filmCategoryRepository.GetByIdAsync(id);

            var categories = await _filmCategoryRepository.GetAllAsync();
            var seats = await _seatRepo.GetAllSeatAsync();
            var schedules = await _scheduleRepo.GetAllAsync();
            var premiere = await _premiereTimeRepo.GetAllAsync();
            var rooms = await _theatreRoomRepo.GetAllRoomAsync();
            var theaters = await _TheaterRepo.GetAllAsync();
            var filmVM = new FilmVM
            {
                Films = categoriesFilm,
                FilmCategories = categories,
                Seats = seats,
                FilmSchedules = schedules,
                PremiereTime = premiere,
                TheatreRooms = rooms,
                Theatres = theaters
            };

            ViewBag.Categoryid = categoryID.Name;
            ViewData["LayoutModel"] = filmVM;
            return View(filmVM);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
