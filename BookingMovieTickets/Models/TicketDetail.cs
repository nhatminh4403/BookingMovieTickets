using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesBooking.Models
{
    public class TicketDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketDetailId { get; set; }
        [Required]
        public int TicketId { get; set; }
 
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int FilmScheduleId { get; set; }

        [ForeignKey("TicketId")]
        public virtual Ticket Ticket { get; set; }

        [ForeignKey("SeatId")]
        public virtual Seat Seat { get; set; }

        [ForeignKey("FilmScheduleId")]
        public virtual FilmSchedule FilmSchedule { get; set; }
    }

}
