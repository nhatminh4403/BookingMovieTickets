using BookingMovieTickets.Models;

namespace BookingMovieTickets.VIewModel
{
    public class EditScheduleVM
    {

        public Film Film { get; set; }
        public IEnumerable<FilmSchedule> FilmSchedules { get; set; }
    }
}
