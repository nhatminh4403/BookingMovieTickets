using BookingMovieTickets.Repository.EF;
using BookingMovieTickets.Repository.Interface;
using BookingMovieTickets.VIewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesBooking.DataAccess;
using MoviesBooking.Models;

namespace BookingMovieTickets.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =UserRole.Role_Admin)]
    public class ManagerController : Controller
    {
        // GET: ManagerController
        private readonly I_FilmCategoryRepository _filmCategoryRepository;
        private readonly I_FilmRepository _filmRepository;
        private readonly I_Seat _seatRepo;
        private readonly BookingMovieTicketsDBContext _dbContext;
        private readonly I_PremiereTime _premiereTimeRepo;
        private readonly I_Schedule _scheduleRepo;
        private readonly I_TheatreRoom _theatreRoomRepo;
        private readonly I_Theater _TheaterRepo;
        public ManagerController(BookingMovieTicketsDBContext dBContext, I_FilmCategoryRepository filmCategoryRepository, I_FilmRepository filmRepository,
            I_PremiereTime premiereTime, I_Seat seatRepo, I_Schedule scheduleRepo, I_TheatreRoom theatreRoomRepo, I_Theater theaterRepo)
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
            ViewData["LayoutModel"] = filmVM;
            return View(filmVM);
        }
        public async Task<IActionResult> GetAllFilm()
        {
            var films = await _filmRepository.GetAllAsync();
            return PartialView("_FilmPartialView", films);
        }
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _filmCategoryRepository.GetAllAsync();
            return PartialView("_CategoriesPartialView", categories);
        }
    }
}
