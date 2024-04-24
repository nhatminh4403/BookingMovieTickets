using BookingMovieTickets.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.DataAccess;
using MoviesBooking.Models;

namespace BookingMovieTickets.Repository.EF
{
    public class EF_Seat : I_Seat
    {
        private readonly MoviesBookingDBContext _dbContext;
        public EF_Seat(MoviesBookingDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Seat>> GetAllSeatAsync()
        {
            return await _dbContext.Seats.ToListAsync(); 
        }
        public async Task<Seat> GetByIdAsync(int id)
        {
            return await _dbContext.Seats.FirstAsync(i => i.SeatId ==id);
        }
        public async Task AddAsync(Seat seat)
        {
            _dbContext.Seats.Add(seat);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Seat seat)
        {
            _dbContext.Seats.Update(seat);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var seat = await _dbContext.Seats.FindAsync(id);
            if(seat != null)
            {
                _dbContext.Seats.Remove(seat);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
