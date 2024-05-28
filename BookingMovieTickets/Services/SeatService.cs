using BookingMovieTickets.DataAccess;
using BookingMovieTickets.Repository.Interface;

namespace BookingMovieTickets.Services
{
    public class SeatService : ISeatService
    {

        private readonly BookingMovieTicketsDBContext _bookingMovieTicketsDBContext;

        public SeatService(BookingMovieTicketsDBContext bookingMovieTicketsDBContext)
        {
            _bookingMovieTicketsDBContext = bookingMovieTicketsDBContext;
        }

        public void ResetSeats()
        {
            var seats = _bookingMovieTicketsDBContext.Seats.ToList();
            foreach (var seat in seats)
            {
                seat.IsBooked = false;
            }
            _bookingMovieTicketsDBContext.SaveChanges();
        }
    }
}
