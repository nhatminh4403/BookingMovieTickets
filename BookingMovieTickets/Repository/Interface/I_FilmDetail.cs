using BookingMovieTickets.Models;
using MoviesBooking.Models;

namespace BookingMovieTickets.Repository.Interface
{
    public interface I_FilmDetail
    {
        Task<IEnumerable<FilmDetails>> GetAllMovieDetailsAsync();
        Task<FilmDetails> GetByIdAsync(int id);
        Task AddAsync(FilmDetails filmDetails);
        Task UpdateAsync(FilmDetails filmDetails);
        Task DeleteAsync(int id);
    }
}
