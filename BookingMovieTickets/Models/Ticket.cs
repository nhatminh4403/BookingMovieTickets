using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesBooking.Models
{
    public class Ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        [DisplayName("Mã vé")]
        public int TicketId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public decimal Price { get; set; }
        [ForeignKey("UserId")]
        public virtual UserInfo User { get; set; }
        public virtual ICollection<TicketDetail> TicketDetails { get; set; }
    }

}
