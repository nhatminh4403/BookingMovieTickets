using BookingMovieTickets.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using MoviesBooking.DataAccess;
using BookingMovieTickets.VIewModel;
using Microsoft.AspNetCore.Authorization;
using MoviesBooking.Models;
namespace BookingMovieTickets.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = UserRole.Role_Admin)]
    public class TheatreRoomController : Controller
    {
        private readonly I_TheatreRoom _TheatreRoomRepository;
        private readonly I_Seat _SeatRepo;
        private readonly I_Schedule _FilmScheduleRepo;
        private readonly BookingMovieTicketsDBContext _dbContext;
        public TheatreRoomController(I_TheatreRoom theatreRoomRepository, I_Seat seatRepo, I_Schedule filmScheduleRepo, BookingMovieTicketsDBContext dbContext)
        {
            _TheatreRoomRepository = theatreRoomRepository;
            _SeatRepo = seatRepo;
            _FilmScheduleRepo = filmScheduleRepo;
            _dbContext = dbContext;
        }

        // GET: TheatreRoomController
        public async Task<IActionResult> Index()
        {
            var rooms = await _TheatreRoomRepository.GetAllRoomAsync();
            return PartialView("_RoomPartialView", rooms);
        }

        // GET: TheatreRoomController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var rooms = await _TheatreRoomRepository.GetByIdAsync(id);
            if(rooms == null)
            {
                return NotFound();
            }
            var seats  = await _SeatRepo.GetAllSeatAsync();
            var roomVM = new RoomVM
            {
                TheatreRoom = rooms,
                Seats = seats
            };
            return View(roomVM);
        }

        // GET: TheatreRoomController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TheatreRoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TheatreRoom theatreRoom)
        {
            if (ModelState.IsValid)
            {
                await _TheatreRoomRepository.AddAsync(theatreRoom); 
                return RedirectToAction("Index", "Manager", new { area = "Admin" });
            }
            return View(theatreRoom);
        }

        // GET: TheatreRoomController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var rooms = await _TheatreRoomRepository.GetByIdAsync(id);
            if (rooms == null)
            {
                return NotFound();
            }
            return View(rooms);
        }

        // POST: TheatreRoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,TheatreRoom theatreRoom)
        {
            if(id != theatreRoom.TheatreRoomId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _TheatreRoomRepository.UpdateAsync(theatreRoom);
                return RedirectToAction("Index", "Manager", new { area = "Admin" });
            }
            return View();
        }

        // GET: TheatreRoomController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var rooms = await _TheatreRoomRepository.GetByIdAsync(id);
            if (rooms == null)
            {
                return NotFound();
            }
            return View(rooms);
        }

        // POST: TheatreRoomController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rooms = await _TheatreRoomRepository.GetByIdAsync(id);
            if (rooms == null)
            {
                await _TheatreRoomRepository.DeleteAsync(id);

            }
            return RedirectToAction("Index", "Manager", new { area = "Admin" });
        }
    }
}
