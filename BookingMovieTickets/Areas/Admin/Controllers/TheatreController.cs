
using BookingMovieTickets.Repository.Interface;
using BookingMovieTickets.VIewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookingMovieTickets.Areas.Admin.Controllers
{
    public class TheatreController : Controller
    {
        private readonly I_Theater _TheaterRepository;
        private readonly I_TheatreRoom _TheaterRoomRepositort;
        public TheatreController(I_Theater theaterRepository, I_TheatreRoom theaterRoomRepositort)
        {
            _TheaterRepository = theaterRepository;
            _TheaterRoomRepositort = theaterRoomRepositort;
        }

        // GET: TheatreController
        public async Task<IActionResult> Index()
        {
            var theaters=  await _TheaterRepository.GetAllAsync();
            return PartialView("_TheaterPartialView", theaters);
        }

        // GET: TheatreController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        // GET: TheatreController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TheatreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TheatreController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        // POST: TheatreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TheatreController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }

        // POST: TheatreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
