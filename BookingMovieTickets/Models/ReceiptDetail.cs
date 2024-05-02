using MoviesBooking.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingMovieTickets.Models
{
    public class ReceiptDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReceiptDetailId { get; set; }
        public int ReceiptId { get; set; }
        [Required]
        public int TicketId { get; set; }
        public virtual Receipt Receipt { get; set; }   
        [ForeignKey("TicketId")]
        public virtual Ticket? Ticket { get; set; }
    }

}
