using BookingMovieTickets.Models;

namespace BookingMovieTickets.Repository.Interface
{
    public interface I_Theater
    {
        Task<IEnumerable<Theatre>> GetAllAsync();
        Task<Theatre> GetByIdAsync(int id);
        Task AddAsync(Theatre theatre);
        Task UpdateAsync(Theatre theatre);
        Task DeleteAsync(int id);
    }
}
