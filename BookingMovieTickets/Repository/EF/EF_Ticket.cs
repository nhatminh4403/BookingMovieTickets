using BookingMovieTickets.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.DataAccess;
using MoviesBooking.Models;
using System.Threading.Tasks;

namespace BookingMovieTickets.Repository.EF
{
    public class EF_Ticket : I_Ticket
    {
        private readonly BookingMovieTicketsDBContext _dbContext;
        public EF_Ticket(BookingMovieTicketsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _dbContext.Tickets.Include(p => p.User).ToListAsync();
        }
        public async Task<Ticket> GetByIdAsync(int id)
        {
            return await _dbContext.Tickets.Include(p => p.User).FirstAsync(p=>p.TicketId == id);
        }
        public async Task AddAsync(Ticket ticket)
        {
            _dbContext.Tickets.Add(ticket);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Ticket ticket)
        {
            _dbContext.Tickets.Update(ticket);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var ticket =  await _dbContext.Tickets.FindAsync(id);
            if(ticket != null)
            {
                _dbContext.Tickets.Remove(ticket);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
