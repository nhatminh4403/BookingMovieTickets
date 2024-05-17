using BookingMovieTickets.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.DataAccess;

namespace BookingMovieTickets.ViewComponents
{
    public class FilmCategoryViewComponent : ViewComponent
    {
        private readonly I_FilmCategoryRepository _filmCategoryRepository;
        private readonly I_FilmRepository _filmRepository;
        private readonly I_Seat _seatRepo;
        private readonly BookingMovieTicketsDBContext _dbContext;
        private readonly I_PremiereTime _premiereTimeRepo;
        private readonly I_Schedule _scheduleRepo;
        private readonly I_TheatreRoom _theatreRoomRepo;
        private readonly I_Theater _TheaterRepo;

        public FilmCategoryViewComponent(I_FilmCategoryRepository filmCategoryService, I_FilmRepository filmRepository, I_Seat seatRepo,BookingMovieTicketsDBContext dbContext,
            I_PremiereTime premiereTimeRepo,I_Schedule scheduleRepo, I_TheatreRoom theatreRoomRepo, I_Theater TheaterRepo)
        {
            _filmCategoryRepository = filmCategoryService;
            _filmRepository = filmRepository;
            _seatRepo = seatRepo;
            _dbContext = dbContext;
            _premiereTimeRepo = premiereTimeRepo;
            _scheduleRepo = scheduleRepo;
            _theatreRoomRepo = theatreRoomRepo;
            _TheaterRepo = TheaterRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _filmCategoryRepository.GetAllAsync();
            return View(categories);
        }
    }

}
