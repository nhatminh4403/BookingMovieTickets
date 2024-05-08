using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesBooking.Models
{
    public class FilmSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FilmScheduleId { get; set; }
        [Required]
        public int FilmId { get; set; }
        [Required]
        public int TheatreRoomId { get; set; }
        [Required]
        public string FilmScheduleDescription { get; set; }
        [ForeignKey(nameof(FilmId))]
        public virtual Film Film { get; set; }
        [ForeignKey(nameof(TheatreRoomId))]
        public virtual TheatreRoom TheatreRoom { get; set; }

        public virtual ICollection<TicketDetail>? TicketDetails { get; set; }

    }
}
