using BookingMovieTickets.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.DataAccess;
using MoviesBooking.Models;

namespace BookingMovieTickets.Repository.EF
{
    public class EF_Schedule : I_Schedule
    {
        private readonly MoviesBookingDBContext _dbContext;
        public EF_Schedule(MoviesBookingDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<FilmSchedule>> GetAllAsync()
        {
            return await _dbContext.FilmsSchedule.Include(p=>p.Film).Include(p=>p.TheatreRoom).ToListAsync();
        }
        public async Task<FilmSchedule> GetByIdAsync(int id)
        {
            return await _dbContext.FilmsSchedule.Include(p => p.Film).Include(p => p.TheatreRoom).FirstAsync(p=>p.FilmScheduleId == id);
        }
        public async Task AddAsync(FilmSchedule filmSchedule)
        {
            _dbContext.FilmsSchedule.Add(filmSchedule);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(FilmSchedule filmSchedule)
        {
            _dbContext.FilmsSchedule.Update(filmSchedule);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var schedule = await _dbContext.FilmsSchedule.FindAsync(id);
            if(schedule != null)
            {
                _dbContext.FilmsSchedule.Remove(schedule);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
