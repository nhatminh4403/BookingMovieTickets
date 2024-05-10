using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.DataAccess;

namespace BookingMovieTickets.Repository.EF
{
    public class EF_Cart : I_Cart
    {
        private readonly BookingMovieTicketsDBContext _dbContext;
        public EF_Cart(BookingMovieTicketsDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<TicketCart>> GetAllAsync()
        {
            return await _dbContext.TicketCarts.ToListAsync();
        }
        public async Task<TicketCart> GetByIdAsync(int id)
        {
            return await _dbContext.TicketCarts.SingleAsync(p=>p.CartId == id);
        }
        public async Task AddAsync(TicketCart ticketCart)
        {
            _dbContext.TicketCarts.Add(ticketCart);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(TicketCart ticketCart)
        {
            _dbContext.TicketCarts.Update(ticketCart);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var cart = await _dbContext.TicketCarts.FindAsync(id);
            if(cart != null)
            {
                _dbContext.TicketCarts.Remove(cart);
                await _dbContext.SaveChangesAsync();
            }
            return;
        }
    }
}
