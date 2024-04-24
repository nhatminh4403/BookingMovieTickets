using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using BookingMovieTickets.Controllers;
using BookingMovieTickets.Models;
using MoviesBooking.Models;

namespace BookingMovieTickets.Repository
{
    public class EFFilmRepository : IFilmRepository
    {
        private readonly ApplicationDbContext _context;
        public EFFilmRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Film>> GetAllAsync()
        {
            // return await _context.Products.ToListAsync(); 
            return await _context.Films
        .Include(p => p.FilmCategory) // Include thông tin về category 
        .ToListAsync();
        }
        public async Task<Film> GetByIdAsync(int id)
        {
            // return await _context.Products.FindAsync(id); 
            // lấy thông tin kèm theo category 
            return await _context.Films.Include(p =>
   p.FilmCategory).FirstOrDefaultAsync(p => p.FilmId == id);
        }
        public async Task AddAsync(Film film)
        {
            _context.Films.Add(film);
            await _context.SaveChangesAsync();
        }
        //public async Task AddShowtimeAsync(FilmSchedule filmSchedule)
        //{
        //    _context.FilmSchedules.Add(filmSchedule);
        //    await _context.SaveChangesAsync();
        //}
        public async Task UpdateAsync(Film film)
        {
            _context.Films.Update(film);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var movie = await _context.Films.FindAsync(id);
            _context.Films.Remove(movie);
            await _context.SaveChangesAsync();
        }

    }
}

