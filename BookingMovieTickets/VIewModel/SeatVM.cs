using MoviesBooking.Models;

namespace BookingMovieTickets.VIewModel
{
    public class SeatVM
    {
        public Film? Film { get; set; }
        public int? ScheduleId { get; set; }
        public IEnumerable<FilmSchedule> Schedules { get; set; }
        public TheatreRoom? TheatreRoom { get; set; }
        public IEnumerable<Seat> Seats { get; set; }
    }
}
