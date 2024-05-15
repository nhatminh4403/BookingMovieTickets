using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesBooking.Models;

namespace BookingMovieTickets.VIewModel
{
    public class LayoutModel : PageModel

    {
        public IEnumerable<FilmCategory> FilmCategories { get; set; }
        public IEnumerable<Film> Films { get; set; }
    }
}
