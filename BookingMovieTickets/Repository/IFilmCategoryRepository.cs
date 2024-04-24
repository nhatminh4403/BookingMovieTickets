using Humanizer.Localisation;
using MoviesBooking.Models;

namespace BookingMovieTickets.Repository
{
    public interface IFilmCategoryRepository
    {
        Task<IEnumerable<FilmCategory>> GetAllAsync();
        Task<FilmCategory> GetByIdAsync(int id);
        Task AddAsync(FilmCategory filmCategory);
        Task UpdateAsync(FilmCategory filmCategory);
        Task DeleteAsync(int id);
    }
}
