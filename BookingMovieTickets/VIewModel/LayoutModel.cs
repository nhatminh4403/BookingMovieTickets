using BookingMovieTickets.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookingMovieTickets.VIewModel
{
    public class LayoutModel : PageModel

    {
        public IEnumerable<FilmCategory> FilmCategories { get; set; }
        public IEnumerable<Film> Films { get; set; }
    }
}
