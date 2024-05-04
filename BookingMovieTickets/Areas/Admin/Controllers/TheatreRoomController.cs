using BookingMovieTickets.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using MoviesBooking.DataAccess;
using BookingMovieTickets.VIewModel;
using Microsoft.AspNetCore.Authorization;
using MoviesBooking.Models;
using Microsoft.EntityFrameworkCore;
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
        public string GenerateSeatNumber(int theaterRoomId, int nextSeatNumber)
        {
            if(theaterRoomId.ToString().Length==1)
                return $"A0{theaterRoomId}-{nextSeatNumber}";
            else
                return $"A{theaterRoomId}-{nextSeatNumber}";
        }
        // GET: /TheatreRoom/AddSeat
        public async Task<IActionResult> AddNewSeat(int theaterRoomId)
        {
            // Retrieve the theater room from the database
            var theaterRoom = await _dbContext.TheatreRooms.FindAsync(theaterRoomId);

            if (theaterRoom != null)
            {
                // Get the maximum seat number for the theater room
                var maxSeatNumber = await _dbContext.Seats
                    .Where(s => s.TheatreRoomId == theaterRoomId)
                    .Select(s => s.SeatNumber)
                    .OrderByDescending(sn => sn)
                    .FirstOrDefaultAsync();

                // Extract the seat number part after the dash
                var nextSeatNumber = 1;
                if (!string.IsNullOrEmpty(maxSeatNumber))
                {
                    var dashIndex = maxSeatNumber.LastIndexOf('-');
                    var seatNumberStr = maxSeatNumber.Substring(dashIndex + 1);
                    if (int.TryParse(seatNumberStr, out int seatNumber))
                    {
                        nextSeatNumber = seatNumber + 1;
                    }
                }

                // Generate the new seat number
                var newSeatNumber = GenerateSeatNumber(theaterRoomId, nextSeatNumber);

                // Create a new seat
                var newSeat = new Seat
                {
                    TheatreRoomId = theaterRoomId,
                    SeatNumber = newSeatNumber,
                    IsBooked = false // or set it to the appropriate initial value
                };

                // Add the new seat to the context and save changes
                await _SeatRepo.AddAsync(newSeat);

                return RedirectToAction("Details", new { id = theaterRoomId });
            }
            else
            {
                return NotFound();
            }
        }
        public async Task<IActionResult> DeleteSeat(int theaterRoomId)
        {
            // Retrieve the theater room from the database
            var theaterRoom = await _dbContext.TheatreRooms.FindAsync(theaterRoomId);

            if (theaterRoom != null)
            {
                // Get the maximum seat number for the theater room
                var maxSeatNumber = await _dbContext.Seats
                    .Where(s => s.TheatreRoomId == theaterRoomId)
                    .OrderByDescending(s => s.SeatId)
                    .FirstOrDefaultAsync();

                // Generate the new seat number
                if(maxSeatNumber != null)
                {
                    _dbContext.Seats.Remove(maxSeatNumber);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Details", new { id = theaterRoomId });
                }
                return RedirectToAction("Details", new { id = theaterRoomId });
            }
            else
            {
                return NotFound();
            }
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
/*            var roomVM = new RoomVM
            {
                TheatreRoom = rooms,
                Seats = seats
            };*/
            return View(rooms);
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
