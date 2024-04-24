using MoviesBooking.Models;

namespace BookingMovieTickets.Repository.Interface
{
    public interface I_PremiereTime
    {
        Task<IEnumerable<PremiereTime>> GetAllAsync();
        Task<PremiereTime> GetByIdAsync(int id);
        Task AddAsync(PremiereTime premiereTime);
        Task UpdateAsync(PremiereTime premiereTime);
        Task DeleteAsync(int id);
    }
}
