using BookingMovieTickets.Models;

namespace BookingMovieTickets.VIewModel
{
    public class DetailVM
    {
        public Film? Film { get; set; }
        public IEnumerable<Film>? Films { get; set; }
        public IEnumerable<FilmCategory>? FilmCategories { get; set; }
    }
}
