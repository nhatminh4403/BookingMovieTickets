﻿
using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.Interface;
using BookingMovieTickets.VIewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BookingMovieTickets.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = UserRole.Role_Admin)]
    public class TheatreController : Controller
    {
        private readonly I_Theater _TheaterRepository;
        private readonly I_TheatreRoom _TheaterRoomRepository;
        private readonly I_Seat _seatRepo;
        public TheatreController(I_Theater theaterRepository, I_TheatreRoom theaterRoomRepository, I_Seat seatRepo)
        {
            _TheaterRepository = theaterRepository;
            _TheaterRoomRepository = theaterRoomRepository;
            _seatRepo = seatRepo;
        }

        // GET: TheatreController
        public async Task<IActionResult> Index()
        {
            var theaters=  await _TheaterRepository.GetAllAsync();
            var rooms = await _TheaterRoomRepository.GetAllRoomAsync();
            var seat = await _seatRepo.GetAllSeatAsync();
            var firstTheatreId = theaters.FirstOrDefault()?.TheatreId ?? theaters.FirstOrDefault().TheatreId;
            var location = new RoomVM
            {
                IDTheatres = firstTheatreId,
                Theatres = theaters,
                TheatreRoom = rooms,
                Seats = seat
            };
            return View(location);
        }

        // GET: TheatreController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var details = await _TheaterRepository.GetByIdAsync(id);
            if(details == null)
            {
                return NotFound();
            }
            return View(details);
        }

        // GET: TheatreController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TheatreController/Create
        [HttpPost]
        public async Task<IActionResult> Create(Theatre theatre)
        {

            if (!ModelState.IsValid)
            {
                await _TheaterRepository.AddAsync(theatre);
                return RedirectToAction(nameof(Index));
            }
            return View(theatre);
        }

        // GET: TheatreController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var theater= await _TheaterRepository.GetByIdAsync(id);
            if(theater == null)
            {
                return NotFound();

            }
            return View(theater);
        }

        // POST: TheatreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Theatre theatre)
        {
            if (id != theatre.TheatreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingLocation = await _TheaterRepository.GetByIdAsync(id);
                existingLocation.Location = theatre.Location;
                existingLocation.Name = theatre.Name;
                await _TheaterRepository.UpdateAsync(theatre);
                return RedirectToAction(nameof(Index));
            }
            return View(theatre);
        }

        // GET: TheatreController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var theatre = await _TheaterRepository.GetByIdAsync(id);
            if(theatre == null)
            {
                return NotFound();
            }
            return View(theatre);
        }

        // POST: TheatreController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _TheaterRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
