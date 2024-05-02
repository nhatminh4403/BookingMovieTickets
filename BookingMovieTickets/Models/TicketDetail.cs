using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesBooking.Models
{
    public class TicketDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketDetailId { get; set; }

        [ForeignKey("Ticket")]
        public int TicketId { get; set; }

        [Required]
        [ForeignKey(nameof(Film))]
        public int FilmId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("FilmSchedule")]
        public int FilmScheduleId { get; set; }
        
        [ForeignKey("Seat")]
        public int SeatId { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual Seat? Seat { get; set; }
        public virtual FilmSchedule? FilmSchedule { get; set; }
        public virtual Film? Film { get; set; }
    }
}
