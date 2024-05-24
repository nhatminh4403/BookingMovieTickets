using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesBooking.Models;

namespace BookingMovieTickets.VIewModel
{
    public class AddScheduleVM
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public IEnumerable<SelectListItem> ScheduleDescriptions { get; set; }
        public IEnumerable<SelectListItem> Rooms { get; set; }
        public IEnumerable<SelectListItem> Theaters { get; set; }
        public FilmSchedule Schedule { get; set; }
    }
}
