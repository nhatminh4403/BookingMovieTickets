using BookingMovieTickets.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesBooking.Models;

namespace BookingMovieTickets.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = UserRole.Role_Admin)]
    public class FilmCategoryController : Controller
    {
        private readonly I_FilmRepository _FilmRepository;
        private readonly I_FilmCategoryRepository _FilmCategoryRepository;
        public FilmCategoryController(I_FilmRepository FilmRepository, I_FilmCategoryRepository FilmCategoryRepository)

        {
            _FilmRepository = FilmRepository;
            _FilmCategoryRepository = FilmCategoryRepository;
        }
        public async Task<IActionResult> Index()
        {

            var categories = await _FilmCategoryRepository.GetAllAsync();
          /*  ViewBag.categories = categories.ToList();*//**/
            return PartialView("_CategoriesPartialView", categories);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(FilmCategory filmCategory)
        {
            if (ModelState.IsValid)
            {
                await _FilmCategoryRepository.AddAsync(filmCategory);
                return RedirectToAction("Index", "Manager", new { area = "Admin" });
            }

            return View(filmCategory);
        }


        public async Task<IActionResult> Edit(int id)
        {

            var FilmCategory = await _FilmCategoryRepository.GetByIdAsync(id);
            if (FilmCategory == null)
            {
                return NotFound();
            }
            ViewBag.FilmCategory = FilmCategory;
            return View(FilmCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, FilmCategory FilmCategory)
        {
            if (id != FilmCategory.FilmCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingCategory = await _FilmCategoryRepository.GetByIdAsync(id);

                existingCategory.Name = FilmCategory.Name;

                await _FilmCategoryRepository.UpdateAsync(existingCategory);
                return RedirectToAction("Index", "Manager", new { area = "Admin" });
            }

            return View(FilmCategory);
        }

        public async Task<IActionResult> Delete(int id)
        {

            var FilmCategory = await _FilmCategoryRepository.GetByIdAsync(id);
            if (FilmCategory == null)
            {
                return NotFound();
            }
            ViewBag.FilmCategory = FilmCategory;
            return View(FilmCategory);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _FilmCategoryRepository.DeleteAsync(id);
            return RedirectToAction("Index","Manager", new {area = "Admin"});
        }
    }
}
