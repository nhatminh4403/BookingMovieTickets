using BookingMovieTickets.Models;


namespace BookingMovieTickets.VIewModel
{
    public class SeatVM : FilmVM
    {
        public Film? Film { get; set; }
        public int? ScheduleId { get; set; }
        public int? ScheduleDescriptionId { get; set; }
        public IEnumerable<FilmSchedule>? Schedules { get; set; }
        public TheatreRoom? TheatreRoom { get; set; }
        public IEnumerable<Seat>? Seats { get; set; }
        public IEnumerable<ScheduleDescription>? ScheduleDescriptions { get; set; }

    }
}
