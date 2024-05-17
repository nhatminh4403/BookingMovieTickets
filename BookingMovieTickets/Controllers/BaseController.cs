using BookingMovieTickets.Repository.Interface;
using BookingMovieTickets.VIewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.DataAccess;

namespace BookingMovieTickets.Controllers
{
    public class BaseController : Controller
    {

        private readonly BookingMovieTicketsDBContext _dbContext;
        public BaseController(BookingMovieTicketsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            // Khởi tạo layoutModel ở đây
            var films = _dbContext.Films
                    .Include(p => p.FilmCategory) // Include thông tin về category 
                    .Include(p => p.PremiereTimes)
                    .Include(p => p.FilmSchedules)
                    .ToList();
            var categories = _dbContext.FilmCategory.Include(p => p.Film).ToList();
            var seats =        _dbContext.Seats.ToList();

            var schedules = _dbContext.FilmSchedules.Include(p => p.Film).Include(p => p.TheatreRoom).Include(p => p.TheatreRoom.Theatre).ToList();
            var premiere = _dbContext.PremiereTimes.Include(p => p.Film).ToList();
            var rooms = _dbContext.TheatreRooms.Include(p => p.Theatre).Include(p => p.FilmSchedules).ToList();
            var theaters = _dbContext.Theatres.Include(p => p.TheatreRooms).ToList();
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
            // Giả sử bạn có một service để lấy dữ liệu thể loại phim
            
            ViewData["LayoutModel"] = filmVM;
        }
    }
}
