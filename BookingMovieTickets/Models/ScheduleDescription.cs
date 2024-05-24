using MoviesBooking.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesBooking.Models
{
    public class ScheduleDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ScheduleDescriptionId { get; set; }
        public TimeSpan Description { get; set; }

        public virtual ICollection<FilmSchedule> FilmSchedules { get; set; }
    }
}
