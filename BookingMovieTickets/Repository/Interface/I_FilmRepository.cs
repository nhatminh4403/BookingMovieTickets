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


        Task<ICollection<Film>> FindByCategoriesAsync(int id);
        Task<IEnumerable<Film>> FindByNameAsync(string name);
        Task<IEnumerable<Film>> GetAllShowAsync(int movieId);
        Task<bool> ExistsAsync(int filmId);
    }
}
