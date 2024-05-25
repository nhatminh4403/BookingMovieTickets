using BookingMovieTickets.DataAccess;
using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.Interface;
using Microsoft.EntityFrameworkCore;



namespace BookingMovieTickets.Repository.EF
{
    public class EF_ScheduleDescription : I_ScheduleDescription
    {
        private readonly BookingMovieTicketsDBContext _dbContext;
        public EF_ScheduleDescription(BookingMovieTicketsDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<ScheduleDescription>> GetAllAsync()
        {
            return await _dbContext.ScheduleDescriptions.Include(p=>p.FilmSchedules).ToListAsync();
        }
        public async Task<ScheduleDescription> GetByIdAsync(int id)
        {
            return await _dbContext.ScheduleDescriptions.Include(p => p.FilmSchedules).FirstAsync(p => p.ScheduleDescriptionId == id);
        }
        public async Task<ScheduleDescription> GetScreentimeByTimeAsync(TimeSpan screenTime)
        {
            return await _dbContext.ScheduleDescriptions.FirstOrDefaultAsync(s => s.Description == screenTime);
        }
    }
}
