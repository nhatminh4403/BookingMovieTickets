using BookingMovieTickets.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.DataAccess;
using MoviesBooking.Models;

namespace BookingMovieTickets.Repository.EF
{
    public class EF_PremiereTime : I_PremiereTime
    {
        private readonly MoviesBookingDBContext _dbContext;
        public EF_PremiereTime(MoviesBookingDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PremiereTime>> GetAllAsync()
        {
            return await _dbContext.PremiereTime.Include(p=>p.FilmSchedules).ToListAsync();
        }
        public async Task<PremiereTime> GetByIdAsync(int id)
        {
            return await _dbContext.PremiereTime.Include(p => p.FilmSchedules).FirstAsync(p=>p.PremiereTimeId == id);
        }
        public async Task AddAsync(PremiereTime premiereTime)
        {
            _dbContext.PremiereTime.Add(premiereTime);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(PremiereTime premiereTime)
        {
            _dbContext.PremiereTime.Update(premiereTime);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var premiereTime = await _dbContext.PremiereTime.FindAsync(id);
            if(premiereTime != null)
            {
                _dbContext.PremiereTime.Remove(premiereTime);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
