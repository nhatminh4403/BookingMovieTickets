﻿using MoviesBooking.Models;

namespace BookingMovieTickets.Repository
{
    public interface IFilmRepository
    {
        Task<IEnumerable<Film>> GetAllAsync();
        Task<Film> GetByIdAsync(int id);
        
        Task AddAsync(Film film);
        Task UpdateAsync(Film film);
        Task DeleteAsync(int id);
        
        
       
    }
}
