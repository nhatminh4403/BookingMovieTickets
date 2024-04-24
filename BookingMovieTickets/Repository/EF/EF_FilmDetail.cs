using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.DataAccess;

namespace BookingMovieTickets.Repository.EF
{
    public class EF_FilmDetail : I_FilmDetail
    {
        private readonly MoviesBookingDBContext _dbContext;
        public EF_FilmDetail(MoviesBookingDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<FilmDetails>> GetAllMovieDetailsAsync()
        {
            return await _dbContext.FilmDetails.ToListAsync();
        }
        public async Task<FilmDetails> GetByIdAsync(int id)
        {
            return await _dbContext.FilmDetails.Include(i=>i.Film).FirstAsync(i=>i.FilmId==id);
        }
        public async Task AddAsync(FilmDetails filmDetails)
        {
            _dbContext.FilmDetails.Add(filmDetails);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(FilmDetails filmDetails)
        {
            _dbContext.FilmDetails.Update(filmDetails);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var details =  await _dbContext.FilmDetails.FindAsync(id);
            if(details != null)
            {
                _dbContext.FilmDetails.Remove(details);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
