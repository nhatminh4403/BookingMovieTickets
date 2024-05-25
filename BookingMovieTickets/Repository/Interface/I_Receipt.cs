using BookingMovieTickets.Models;

namespace BookingMovieTickets.Repository.Interface
{
    public interface I_Receipt
    {
        Task<IEnumerable<Receipt>> GetAllAsync();
        Task<Receipt> GetByIdAsync(int id);
        Task AddAsync(Receipt receipt);
        Task UpdateAsync(Receipt receipt);
        Task DeleteAsync(int id);
    }
}
