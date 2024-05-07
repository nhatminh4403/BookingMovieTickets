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

        public HomeController(BookingMovieTicketsDBContext dBContext, I_FilmCategoryRepository filmCategoryRepository, I_FilmRepository filmRepository,
            I_PremiereTime premiereTime, I_Seat seatRepo, I_Schedule scheduleRepo, I_TheatreRoom theatreRoomRepo, I_Theater theaterRepo, ILogger<HomeController> logger, UserManager<UserInfo> userManager)
        {
            _dbContext = dBContext;
            _filmRepository = filmRepository;
            _seatRepo = seatRepo;
            _scheduleRepo = scheduleRepo;
            _filmCategoryRepository = filmCategoryRepository;
            _premiereTimeRepo = premiereTime;
            _theatreRoomRepo = theatreRoomRepo;
            _TheaterRepo = theaterRepo;
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
