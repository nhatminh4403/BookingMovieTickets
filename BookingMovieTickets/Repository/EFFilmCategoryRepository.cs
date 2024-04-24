using BookingMovieTickets.Models;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.Models;

namespace BookingMovieTickets.Repository
{
    public class EFFilmCategoryRepository : IFilmCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public EFFilmCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FilmCategory>> GetAllAsync()
        {
            return await _context.FilmCategories.ToListAsync();
        }
        public async Task<FilmCategory> GetByIdAsync(int id)
        {
            return await _context.FilmCategories.FindAsync(id);
        }
        public async Task AddAsync(FilmCategory filmCategory)
        {
            _context.FilmCategories.Add(filmCategory);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(FilmCategory filmCategory)
        {
            _context.FilmCategories.Update(filmCategory);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var category = await _context.FilmCategories.FindAsync(id);
            _context.FilmCategories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
