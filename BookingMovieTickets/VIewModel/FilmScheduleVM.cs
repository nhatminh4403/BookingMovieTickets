using MoviesBooking.Models;

namespace BookingMovieTickets.VIewModel
{
    public class FilmScheduleVM
    {
        public IEnumerable<Film> FilmsWithSchedules { get; set; }
        public IEnumerable<Film> FilmsWithoutSchedulesStartDateBeforeNow { get; set; }
        public IEnumerable<Film> FilmsWithoutSchedulesStartDateAfterNow { get; set; }

    }
}
