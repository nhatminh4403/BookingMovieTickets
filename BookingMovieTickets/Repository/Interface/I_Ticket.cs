using BookingMovieTickets.Models;

namespace BookingMovieTickets.Repository.Interface
{
    public interface I_Ticket
    {
        Task<IEnumerable<Ticket>> GetAllAsync();
        Task<Ticket> GetByIdAsync(int id);
        Task AddAsync(Ticket ticket);
        Task UpdateAsync(Ticket ticket);
        Task DeleteAsync(int id);
    }
}
