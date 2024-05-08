using MoviesBooking.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingMovieTickets.Models
{
    public class TicketCartDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartDetailId { get; set; }

        [Required]
        public int CartId { get; set; }
        [Required]
        public int TicketId { get; set; }
        [ForeignKey("CartId")]
        public virtual TicketCart TicketCart { get; set; }
        [ForeignKey("TicketId")]
        public virtual Ticket Ticket { get; set; }
    }
}
