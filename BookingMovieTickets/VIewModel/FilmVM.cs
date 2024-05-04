using MoviesBooking.Models;

namespace BookingMovieTickets.VIewModel
{
    public class FilmVM
    {
        public IEnumerable<Film> Films { get; set; }
        public IEnumerable<FilmCategory> FilmCategories { get; set; }
        public IEnumerable<FilmSchedule> FilmSchedules { get; set;}
        public IEnumerable<Seat> Seats { get; set; }
        public IEnumerable<TheatreRoom> TheatreRooms { get; set; }
        public IEnumerable<PremiereTime> PremiereTime { get; set;}
        public IEnumerable<Theatre> Theatres { get; set; }
    }
}
