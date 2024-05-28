using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingMovieTickets.Models
{
    public class Ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        [DisplayName("Mã vé")]
        public int TicketId { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }

        public virtual ICollection<ReceiptDetail> ReceiptDetails { get; set; }
        public virtual ICollection<TicketDetail> TicketDetails { get; set; }
        public virtual ICollection<TicketCartDetail> TicketCartDetails { get; set; }
    }
}
