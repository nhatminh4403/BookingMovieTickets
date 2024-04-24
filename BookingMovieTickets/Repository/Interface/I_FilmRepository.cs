using MoviesBooking.Models;

namespace BookingMovieTickets.Repository.Interface
{
    public interface I_FilmRepository
    {
        Task<IEnumerable<Film>> GetAllAsync();
        Task<Film> GetByIdAsync(int id);

        Task AddAsync(Film film);
        Task UpdateAsync(Film film);
        Task DeleteAsync(int id);



    }
}
