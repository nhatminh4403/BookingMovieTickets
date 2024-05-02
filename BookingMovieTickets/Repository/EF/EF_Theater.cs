using BookingMovieTickets.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.DataAccess;
using MoviesBooking.Models;
using System.Threading.Tasks;

namespace BookingMovieTickets.Repository.EF
{
    public class EF_Theater : I_Theater
    {
        private readonly BookingMovieTicketsDBContext _dbContext;
        public EF_Theater(BookingMovieTicketsDBContext context) 
        {
            _dbContext = context;
        }
        public async Task<IEnumerable<Theatre>> GetAllAsync()
        {
            return await _dbContext.Theatres.ToListAsync();
        }
        public async Task<Theatre> GetByIdAsync(int id)
        {
            return await _dbContext.Theatres.FirstAsync(i => i.TheatreId == id);
        }
        public async Task AddAsync(Theatre theatre)
        {
            _dbContext.Theatres.Add(theatre);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Theatre theatre)
        {
            _dbContext.Theatres.Update(theatre);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var theater =  await _dbContext.Theatres.FindAsync(id);
            if(theater !=null) 
            {
                _dbContext.Theatres.Remove(theater);
                await _dbContext.SaveChangesAsync();
            }
        }
    }

}
