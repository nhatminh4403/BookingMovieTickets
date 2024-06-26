﻿using BookingMovieTickets.DataAccess;
using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookingMovieTickets.Repository.EF
{
    public class EF_Schedule : I_Schedule
    {
        private readonly BookingMovieTicketsDBContext _dbContext;
        public EF_Schedule(BookingMovieTicketsDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<FilmSchedule>> GetAllAsync()
        {
            return await _dbContext.FilmSchedules.Include(p=>p.Film).Include(p=>p.ScheduleDescription).Include(p=>p.TheatreRoom).Include(p=>p.TheatreRoom.Theatre).ToListAsync();
        }
        public async Task<FilmSchedule> GetByIdAsync(int id)
        {
            return await _dbContext.FilmSchedules.Include(p => p.Film).Include(p => p.ScheduleDescription).Include(p => p.TheatreRoom).Include(p => p.TheatreRoom.Theatre).FirstAsync(p=>p.FilmScheduleId == id);
        }
        public async Task AddAsync(FilmSchedule filmSchedule)
        {
            _dbContext.FilmSchedules.Add(filmSchedule);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(FilmSchedule filmSchedule)
        {
            _dbContext.FilmSchedules.Update(filmSchedule);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var schedule = await _dbContext.FilmSchedules.FindAsync(id);
            if(schedule != null)
            {
                _dbContext.FilmSchedules.Remove(schedule);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<FilmSchedule> GetFilmByIdAsync(int id)
        {
            var film = await _dbContext.FilmSchedules.Include(p => p.Film).FirstOrDefaultAsync(p=>p.FilmId == id);
            return film;
        }
        public async Task<FilmSchedule> GetScheduleByDetailsAsync(FilmSchedule filmSchedule)
        {
          
            return await _dbContext.FilmSchedules
                .FirstOrDefaultAsync(fs => fs.FilmId == filmSchedule.FilmId &&
                                            fs.TheatreRoomId == filmSchedule.TheatreRoomId &&
                                            fs.ScheduleDescriptionId == filmSchedule.ScheduleDescriptionId);
        }

    }
}
