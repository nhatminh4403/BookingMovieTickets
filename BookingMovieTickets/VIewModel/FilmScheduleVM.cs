using MoviesBooking.Models;

namespace BookingMovieTickets.VIewModel
{
    public class FilmScheduleVM
    {
        public IEnumerable<Film> FilmsWithSchedules { get; set; }
        public IEnumerable<Film> FilmsWithoutSchedules { get; set; }

    }
}
