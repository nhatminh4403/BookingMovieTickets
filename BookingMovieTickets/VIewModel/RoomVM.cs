using MoviesBooking.Models;

namespace BookingMovieTickets.VIewModel
{
    public class RoomVM
    {
        public IEnumerable<Theatre> Theatres { get; set; }
        public IEnumerable< TheatreRoom> TheatreRoom { get; set; }
        public IEnumerable<Seat> Seats { get; set; }
        public IEnumerable<FilmSchedule> FilmSchedules { get; set;}
    }
}
