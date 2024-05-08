using BookingMovieTickets.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.DataAccess;
using MoviesBooking.Models;

namespace BookingMovieTickets.Repository.EF
{
    public class EF_TicketDetail : I_TicketDetail
    {
        private readonly BookingMovieTicketsDBContext _dbContext;
        public EF_TicketDetail(BookingMovieTicketsDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<TicketDetail>> GetAllAsync()
        {
            return await _dbContext.TicketDetails
                .Include(x => x.Ticket)
                .Include(x=>x.FilmSchedule)
                .Include(x=> x.Seat)
                .ToListAsync();
        }
        public async Task<TicketDetail> GetByIdAsync(int id)
        {
            return await _dbContext.TicketDetails
                .Include(x => x.Ticket)
                .Include(x => x.FilmSchedule)
                .Include(x => x.Seat)
                .FirstAsync(x=>x.TicketDetailId == id);
        }
        public async Task AddAsync(TicketDetail ticketDetail)
        {
            _dbContext.TicketDetails.Add(ticketDetail);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(TicketDetail ticketDetail)
        {
            _dbContext.TicketDetails.Update(ticketDetail);
            await _dbContext.SaveChangesAsync();
        }
    }
}
