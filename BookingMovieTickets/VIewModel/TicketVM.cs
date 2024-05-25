using BookingMovieTickets.Models;
using MoviesBooking.Models;

namespace BookingMovieTickets.VIewModel
{
    public class TicketVM
    {
        public TicketCart? TicketCart { get; set; }
        public Receipt? Receipt { get; set; }
    }
}
