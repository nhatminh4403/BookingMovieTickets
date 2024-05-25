using BookingMovieTickets.Models;

namespace BookingMovieTickets.Repository.Interface
{
    public interface I_TicketDetail
    {
        Task<IEnumerable<TicketDetail>> GetAllAsync();
        Task<TicketDetail> GetByIdAsync(int id);
        Task AddAsync(TicketDetail ticketDetail);
        Task UpdateAsync(TicketDetail ticketDetail);
    }
}
