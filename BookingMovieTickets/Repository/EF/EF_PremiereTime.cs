using BookingMovieTickets.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.DataAccess;
using MoviesBooking.Models;

namespace BookingMovieTickets.Repository.EF
{
    public class EF_PremiereTime : I_PremiereTime
    {
        private readonly BookingMovieTicketsDBContext _dbContext;
        public EF_PremiereTime(BookingMovieTicketsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PremiereTime>> GetAllAsync()
        {
            return await _dbContext.PremiereTimes.Include(p=>p.Film).ToListAsync();
        }
        public async Task<PremiereTime> GetByIdAsync(int id)
        {
            return await _dbContext.PremiereTimes.Include(p => p.Film).FirstAsync(p=>p.PremiereTimeId == id);
        }
        public async Task AddAsync(PremiereTime premiereTime)
        {
            _dbContext.PremiereTimes.Add(premiereTime);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(PremiereTime premiereTime)
        {
            _dbContext.PremiereTimes.Update(premiereTime);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var premiereTime = await _dbContext.PremiereTimes.FindAsync(id);
            if(premiereTime != null)
            {
                _dbContext.PremiereTimes.Remove(premiereTime);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
