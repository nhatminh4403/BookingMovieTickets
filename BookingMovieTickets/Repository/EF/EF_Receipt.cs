using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.DataAccess;

namespace BookingMovieTickets.Repository.EF
{
    public class EF_Receipt : I_Receipt
    {
        private readonly BookingMovieTicketsDBContext _dbContext;
        public EF_Receipt(BookingMovieTicketsDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Receipt>> GetAllAsync()
        {
            return await _dbContext.Receipts.Include(p=>p.User).ToListAsync();
        }
        public async Task<Receipt> GetByIdAsync(int id)
        {
            return await _dbContext.Receipts.Include(p => p.User).FirstAsync(p=>p.ReceiptId==id);
        }
        public async Task AddAsync(Receipt receipt)
        {
            _dbContext.Receipts.Add(receipt);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Receipt receipt)
        {
            _dbContext.Receipts.Update(receipt);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var receipt = await _dbContext.Receipts.FindAsync(id);
            if(receipt != null)
            {
                _dbContext.Receipts.Remove(receipt);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
