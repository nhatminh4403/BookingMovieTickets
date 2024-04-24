using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.DataAccess;

namespace BookingMovieTickets.Repository.EF
{
    public class EF_Receipt : I_Receipt
    {
        private readonly MoviesBookingDBContext _dbContext;
        public EF_Receipt(MoviesBookingDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Receipt>> GetAllAsync()
        {
            return await _dbContext.Receipt.Include(p=>p.User).ToListAsync();
        }
        public async Task<Receipt> GetByIdAsync(int id)
        {
            return await _dbContext.Receipt.Include(p => p.User).FirstAsync(p=>p.ReceiptId==id);
        }
        public async Task AddAsync(Receipt receipt)
        {
            _dbContext.Receipt.Add(receipt);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Receipt receipt)
        {
            _dbContext.Receipt.Update(receipt);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var receipt = await _dbContext.Receipt.FindAsync(id);
            if(receipt != null)
            {
                _dbContext.Receipt.Remove(receipt);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
