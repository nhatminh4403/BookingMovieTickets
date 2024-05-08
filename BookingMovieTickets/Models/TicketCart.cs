using MoviesBooking.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingMovieTickets.Models
{
    public class TicketCart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual UserInfo UserInfo { get; set; }
    }
}
