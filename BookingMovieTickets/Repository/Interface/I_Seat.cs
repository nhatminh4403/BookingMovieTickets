using MoviesBooking.Models;

namespace BookingMovieTickets.Repository.Interface
{
    public interface I_Seat
    {
        Task<IEnumerable<Seat>> GetAllSeatAsync();
        Task<Seat> GetByIdAsync(int id);
        Task AddAsync(Seat seat);
        Task UpdateAsync(Seat seat);
        Task DeleteAsync(int id);
    }
}
