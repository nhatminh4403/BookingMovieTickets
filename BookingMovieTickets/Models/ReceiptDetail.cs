using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesBooking.Models
{
    public class ReceiptDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReceiptDetailId { get; set; }
        [Required]
        public int ReceiptId { get; set; }

        [Required]
        public int TicketId { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        // Other properties as needed
        [ForeignKey("ReceiptId")]
        public virtual Receipt Receipt { get; set; }

        [ForeignKey("TicketId")]
        public virtual Ticket Ticket { get; set; }
    }

}
