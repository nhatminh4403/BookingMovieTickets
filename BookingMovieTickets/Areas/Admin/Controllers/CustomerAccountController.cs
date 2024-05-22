using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoviesBooking.Models;
using System.Data;

namespace BookingMovieTickets.Areas.Admin.Controllers
{
    [Authorize(Roles = UserRole.Role_Admin)]
    [Area("Admin")]
    public class CustomerAccountController : Controller
    {
        private readonly UserManager<UserInfo> _userManager;
        public CustomerAccountController(UserManager<UserInfo> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            IList<UserInfo> customer = await _userManager.GetUsersInRoleAsync("Customer");
            return View(customer);
        }
        
        // GET: CustomerAccountController/Details/5
        public  ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerAccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerAccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CustomerAccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerAccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: CustomerAccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerAccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
