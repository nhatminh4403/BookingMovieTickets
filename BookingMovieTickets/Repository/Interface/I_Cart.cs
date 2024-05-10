using BookingMovieTickets.Models;

namespace BookingMovieTickets.Repository.Interface
{
    public interface I_Cart
    {
        Task<IEnumerable<TicketCart>> GetAllAsync();
        Task<TicketCart> GetByIdAsync(int id);
        Task AddAsync(TicketCart ticketCart);
        Task UpdateAsync(TicketCart ticketCart);
        Task DeleteAsync(int id);
    }
}
