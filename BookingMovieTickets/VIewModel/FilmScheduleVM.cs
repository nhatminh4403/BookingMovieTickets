using MoviesBooking.Models;

namespace BookingMovieTickets.VIewModel
{
    public class FilmScheduleVM
    {
        public int FilmId { get; set; }
        public string FilmName { get; set;}
        public int TheatreRoomId { get; set; }
        public string RoomName { get; set; }
        public int TheatreId { get; set; }
        public string Name { get; set; }
    //    public IEnumerable<FilmSchedule> FilmSchedules { get; set; }

    }
}
