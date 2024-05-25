using BookingMovieTickets.Models;

namespace BookingMovieTickets.Repository.Interface
{
    public interface I_TheatreRoom
    {
        Task<IEnumerable<TheatreRoom>> GetAllRoomAsync();
        Task<TheatreRoom> GetByIdAsync(int id);
        Task AddAsync(TheatreRoom theatreRoom);
        Task UpdateAsync(TheatreRoom theatreRoom);
        Task DeleteAsync(int id);
    }
}
