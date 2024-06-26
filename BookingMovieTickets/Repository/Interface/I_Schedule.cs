﻿using BookingMovieTickets.Models;

namespace BookingMovieTickets.Repository.Interface
{
    public interface I_Schedule
    {
        Task<IEnumerable<FilmSchedule>> GetAllAsync();
        Task<FilmSchedule> GetByIdAsync(int id);
        Task AddAsync(FilmSchedule filmSchedule);
        Task UpdateAsync(FilmSchedule filmSchedule);
        Task DeleteAsync(int id);
        Task<FilmSchedule> GetFilmByIdAsync(int id);
        Task<FilmSchedule> GetScheduleByDetailsAsync(FilmSchedule filmSchedule);
    }
}
