using BookingMovieTickets.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.DataAccess;
using MoviesBooking.Models;
using System.Threading.Tasks;

namespace BookingMovieTickets.Repository.EF
{
    public class EF_Ticket : I_Ticket
    {
        private readonly MoviesBookingDBContext _dbContext;
        public EF_Ticket(MoviesBookingDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _dbContext.Ticket.Include(p => p.User).ToListAsync();
        }
        public async Task<Ticket> GetByIdAsync(int id)
        {
            return await _dbContext.Ticket.Include(p => p.User).FirstAsync(p=>p.TicketId == id);
        }
        public async Task AddAsync(Ticket ticket)
        {
            _dbContext.Ticket.Add(ticket);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Ticket ticket)
        {
            _dbContext.Ticket.Update(ticket);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var ticket =  await _dbContext.Ticket.FindAsync(id);
            if(ticket != null)
            {
                _dbContext.Ticket.Remove(ticket);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
