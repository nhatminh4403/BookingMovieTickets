using BookingMovieTickets.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesBooking.Models;

namespace BookingMovieTickets.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = UserRole.Role_Admin)]
    public class MovieController : Controller
    {     

            private readonly I_FilmRepository _FilmRepository;
            private readonly I_FilmCategoryRepository _FilmCategoryRepository;
            public MovieController(I_FilmRepository filmRepository,
            I_FilmCategoryRepository filmCategoryRepository)
            {
                _FilmRepository = filmRepository;
                _FilmCategoryRepository = filmCategoryRepository;
            }
            // Hiển thị danh sách sản phẩm
            public async Task<IActionResult> Index()
            {
                var films = await _FilmRepository.GetAllAsync();
            return View(films); 
            }
            // Hiển thị form thêm sản phẩm mới
            public async Task<IActionResult> Add()
            {
                var FilmCategory = await _FilmCategoryRepository.GetAllAsync();
                ViewBag.FilmCategory = new SelectList(FilmCategory, "FilmCategoryId", "Name");
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> Add(Film film, IFormFile PosterUrl)
            {
                if (ModelState.IsValid)
                {
                    if (PosterUrl != null)
                    {
                        if (ValidateImageExtension(PosterUrl.FileName))
                        {
                            if (!ValidatImageSize(PosterUrl, 5242880))
                            {
                                ModelState.AddModelError("PosterUrl", "Image size is too big. The limit is only 5MB");
                                return View(film);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("PosterUrl", "Invalid image format for main image. Please upload a jpg, jpeg, jfif, or png file.");
                            return View(film);
                        }
                        film.PosterUrl = await SaveImage(PosterUrl);
                    }
                    await _FilmRepository.AddAsync(film);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("PosterUrl", "Please enter a image.");
                    // Nếu ModelState không hợp lệ, hiển thị form với dữ liệu đã nhập
                    var filmCategories = await _FilmCategoryRepository.GetAllAsync();
                    ViewBag.FilmCategories = new SelectList(filmCategories, "FilmCategoryId", "Description");
                    return View(film);
                }

            }

            private async Task<string> SaveImage(IFormFile image)
            {
                var savePath = Path.Combine("wwwroot/images", image.FileName); // Thay đổi đường dẫn theo cấu hình của bạn     
                using (var fileStream = new FileStream(savePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                return "~/images/" + image.FileName; // Trả về đường dẫn tương đối
            }
            public async Task<IActionResult> Display(int id)
            {
                var film = await _FilmRepository.GetByIdAsync(id);
                if (film == null)
                {
                    return NotFound();
                }

                return View(film);
            }
            // Hiển thị form cập nhật sản phẩm 
            public async Task<IActionResult> Update(int id)
            {
                var film = await _FilmRepository.GetByIdAsync(id);
                if (film == null)
                {
                    return NotFound();
                }

                var filmCategories = await _FilmCategoryRepository.GetAllAsync();
                ViewBag.FilmCategories = new SelectList(filmCategories, "FilmCategoryId", "Name",
                film.FilmCategoryId);
                return View(film);
            }

            // Xử lý cập nhật sản phẩm
            [HttpPost]
            public async Task<IActionResult> Update(int id, Film film, IFormFile PosterUrl)

            {
                ModelState.Remove("PosterUrl"); // Loại bỏ xác thực ModelState cho ImageUrl
                if (id != film.FilmId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    var existingMovie = await

                    _FilmRepository.GetByIdAsync(id); // Giả định có phương thức GetByIdAsync
                                                      // Giữ nguyên thông tin hình ảnh nếu không có hình mới được tải lên
                    if (PosterUrl == null)
                    {
                        film.PosterUrl = existingMovie.PosterUrl;
                    }
                    else
                    {
                        if (ValidateImageExtension(PosterUrl.FileName))
                        {
                            if (!ValidatImageSize(PosterUrl, 5242880))
                            {
                                ModelState.AddModelError("PosterUrl", "Image size is too big. The limit is only 1MB");
                                return View(film);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("Poster", "Invalid image format for main image. Please upload a jpg, jpeg, jfif, or png file.");
                            return View(film);
                        }
                        // Lưu hình ảnh mới
                        film.PosterUrl = await SaveImage(PosterUrl);
                    }
                    // Cập nhật các thông tin khác của sản phẩm
                    existingMovie.NameFilm = film.NameFilm;
                    existingMovie.Description = film.Description;
                    existingMovie.PosterUrl = film.PosterUrl;

                    existingMovie.TrailerUrl = film.TrailerUrl;
                    existingMovie.PremiereDate = film.PremiereDate;
                    existingMovie.DirectorName = film.DirectorName;
                    existingMovie.Language = film.Language;
                    existingMovie.FilmRated = film.FilmRated;
                    existingMovie.FilmDuration = film.FilmDuration;
                    existingMovie.Actors = film.Actors;
                    await _FilmRepository.UpdateAsync(existingMovie);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("PosterUrl", "Please enter a image.");
                    var filmCategories = await _FilmCategoryRepository.GetAllAsync();
                    ViewBag.FilmCategories = new SelectList(filmCategories, "FilmCategoryId", "Name");
                    return View(film);
                }

            }
            public async Task<IActionResult> Delete(int id)
            {
                var film = await _FilmRepository.GetByIdAsync(id);
                if (film == null)
                {
                    return NotFound();
                }
                return View(film);
            }
            [HttpPost, ActionName("DeleteConfirmed")]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                await _FilmRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }

            private bool ValidateImageExtension(string fileName)
            {
                var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png", ".jfif" };
                return allowedExtensions.Contains(Path.GetExtension(fileName).ToLower());
            }
            private bool ValidatImageSize(IFormFile file, long maximumSize)
            {
                return file.Length <= maximumSize;
            }
        }
    }

