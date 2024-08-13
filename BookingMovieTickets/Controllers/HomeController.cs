using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.Interface;
using BookingMovieTickets.VIewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TextTemplating;

using System.Collections.Generic;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using BookingMovieTickets.Helper;
using BookingMovieTickets.DataAccess;
namespace BookingMovieTickets.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<UserInfo> _userManager;
        private readonly I_FilmCategoryRepository _filmCategoryRepository;
        private readonly I_FilmRepository _filmRepository;
        private readonly I_Seat _seatRepo;
        private readonly BookingMovieTicketsDBContext _dbContext;
        private readonly I_Schedule _scheduleRepo;
        private readonly I_TheatreRoom _theatreRoomRepo;
        private readonly I_Theater _TheaterRepo;

        public HomeController(ILogger<HomeController> logger, UserManager<UserInfo> userManager, I_FilmCategoryRepository filmCategoryRepository, I_FilmRepository filmRepository,
             I_Seat seatRepo, I_Schedule scheduleRepo, I_TheatreRoom theatreRoomRepo, I_Theater theaterRepo, BookingMovieTicketsDBContext dbContext ) : base(dbContext)
        {
            _logger = logger;
            _userManager = userManager;
            _filmRepository = filmRepository;
            _seatRepo = seatRepo;
            _scheduleRepo = scheduleRepo;
            _filmCategoryRepository = filmCategoryRepository;
            
            _theatreRoomRepo = theatreRoomRepo;
            _TheaterRepo = theaterRepo;
            _dbContext = dbContext;
            
        }
        public async Task<IActionResult> UpcomingFilm()
        {
            var upcoming = await _dbContext.Films.Where(p => p.StartTime > DateTime.UtcNow).ToListAsync();

            return View(upcoming);
        }
        public async Task<IActionResult> phim_dang_chieu()
        {
            var whatNow = await _dbContext.Films.Where(p => p.StartTime <= DateTime.UtcNow).ToListAsync();
            return View(whatNow);
        }
        public async Task<IActionResult> Index()
        {
            var films = await _filmRepository.GetAllAsync();
            var categories = await _filmCategoryRepository.GetAllAsync();
            var seats = await _seatRepo.GetAllSeatAsync();
            var schedules = await _scheduleRepo.GetAllAsync();
            var rooms = await _theatreRoomRepo.GetAllRoomAsync();
            var theaters = await _TheaterRepo.GetAllAsync();
            var filmVM = new FilmVM
            {
                Films = films,
                FilmCategories = categories,
                Seats = seats,
                FilmSchedules = schedules,
                TheatreRooms = rooms,
                Theatres = theaters
            };

/*            ViewData["LayoutModel"] = filmVM;
*/            ViewData["FilmCategories"] = categories;
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
            var film = await _dbContext.Films.Include(p => p.FilmCategory).Include(f => f.FilmSchedules).ThenInclude(fs => fs.TheatreRoom)
                                             .ThenInclude(tr => tr.Theatre).Include(f => f.FilmSchedules)
                                            .ThenInclude(fs => fs.ScheduleDescription)
                                             .FirstOrDefaultAsync(f => f.FilmId == id);
            var films = await _filmRepository.GetAllAsync();
            var categories = await _filmCategoryRepository.GetAllAsync();
            if (film == null)
            {
                return NotFound();
            }
            var filmsDetailVM = new DetailVM
            {
                Film = film,
                FilmCategories = categories,
                Films= films
                
            };
            return View(filmsDetailVM);
        }

        public async Task<IActionResult> AllFilm(string namefilm)
        {
            var films = await _filmRepository.GetAllAsync();
            var categories = await _filmCategoryRepository.GetAllAsync();
            var seats = await _seatRepo.GetAllSeatAsync();
            var schedules = await _scheduleRepo.GetAllAsync();
            var rooms = await _theatreRoomRepo.GetAllRoomAsync();
            var theaters = await _TheaterRepo.GetAllAsync();

            if (!string.IsNullOrEmpty(namefilm))
            {
                var normalizedSearchString = StringHelper.RemoveDiacritics(namefilm).ToLower();
                films = films.Where(f => StringHelper.RemoveDiacritics(f.NameFilm).ToLower().Contains(normalizedSearchString)).ToList();
            }
            var filmVM = new FilmVM
            {
                Films = films,
                FilmCategories = categories,
                Seats = seats,
                FilmSchedules = schedules,

                TheatreRooms = rooms,
                Theatres = theaters
            };
            return View(filmVM);
        }


        public async Task<IActionResult> SearchByName(string film)
        {

            var name = await _filmRepository.FindByNameAsync(film);
            
            return View("SearchByName", name);
        }
        public async Task<IActionResult> SortFilmsByCategories(int id)
        {

            var categoriesFilm = await _filmRepository.FindByCategoriesAsync(id);

            var categoryID = await _filmCategoryRepository.GetByIdAsync(id);

            var categories = await _filmCategoryRepository.GetAllAsync();
            var seats = await _seatRepo.GetAllSeatAsync();
            var schedules = await _scheduleRepo.GetAllAsync();
            var rooms = await _theatreRoomRepo.GetAllRoomAsync();
            var theaters = await _TheaterRepo.GetAllAsync();
            var filmVM = new FilmVM
            {
                Films = categoriesFilm,
                FilmCategories = categories,
                Seats = seats,
                FilmSchedules = schedules,

                TheatreRooms = rooms,
                Theatres = theaters
            };
            
            ViewBag.Categoryid = categoryID.Name;
            ViewData["LayoutModel"] = filmVM;
            return View(filmVM);
        }
        public IActionResult FAQs()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
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
