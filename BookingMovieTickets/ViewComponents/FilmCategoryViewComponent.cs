using BookingMovieTickets.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingMovieTickets.DataAccess;

namespace BookingMovieTickets.ViewComponents
{
    public class FilmCategoryViewComponent : ViewComponent
    {
        private readonly I_FilmCategoryRepository _filmCategoryRepository;

        public FilmCategoryViewComponent(I_FilmCategoryRepository filmCategoryService)
        {
            _filmCategoryRepository = filmCategoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _filmCategoryRepository.GetAllAsync();
            return View(categories);
        }
    }

}
