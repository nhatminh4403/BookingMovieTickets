using BookingMovieTickets.DataAccess;
using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.Interface;
using Microsoft.EntityFrameworkCore;


namespace BookingMovieTickets.Repository.EF
{
    public class EF_FilmCategoryRepository : I_FilmCategoryRepository
    {
        private readonly BookingMovieTicketsDBContext _context;
        public EF_FilmCategoryRepository(BookingMovieTicketsDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FilmCategory>> GetAllAsync()
        {
            return await _context.FilmCategory.Include(p=>p.Film).ToListAsync();
        }
        public async Task<FilmCategory> GetByIdAsync(int id)
        {
            return await _context.FilmCategory.Include(p => p.Film).FirstAsync(i=> i.FilmCategoryId ==  id);
        }
        public async Task AddAsync(FilmCategory filmCategory)
        {
            _context.FilmCategory.Add(filmCategory);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(FilmCategory filmCategory)
        {
            _context.FilmCategory.Update(filmCategory);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var category = await _context.FilmCategory.FindAsync(id);
            if(category != null) 
            { 
                _context.FilmCategory.Remove(category);
              await _context.SaveChangesAsync();
            }
            
        }
    }
}
