using BookingMovieTickets.DataAccess;
using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.Interface;
using Microsoft.EntityFrameworkCore;


namespace BookingMovieTickets.Repository.EF
{
    public class EF_Seat : I_Seat
    {
        private readonly BookingMovieTicketsDBContext _dbContext;
        public EF_Seat(BookingMovieTicketsDBContext dbContext)
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
