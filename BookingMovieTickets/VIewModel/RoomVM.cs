using MoviesBooking.Models;

namespace BookingMovieTickets.VIewModel
{
    public class RoomVM
    {
        public TheatreRoom TheatreRoom { get; set; }
        public IEnumerable<Seat> Seats { get; set; }
    }
}
