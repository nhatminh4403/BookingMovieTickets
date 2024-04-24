using Humanizer.Localisation;
using MoviesBooking.Models;

namespace BookingMovieTickets.Repository.Interface
{
    public interface I_FilmCategoryRepository
    {
        Task<IEnumerable<FilmCategory>> GetAllAsync();
        Task<FilmCategory> GetByIdAsync(int id);
        Task AddAsync(FilmCategory filmCategory);
        Task UpdateAsync(FilmCategory filmCategory);
        Task DeleteAsync(int id);
    }
}
