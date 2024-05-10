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
        [NotMapped]
        public List<TicketCartDetail> Items { get; set; } = new List<TicketCartDetail>();
        public void AddItem(TicketCartDetail item)
        {
            var existingItem = Items.FirstOrDefault(i => i.TicketId == item.TicketId);
            if (existingItem == null)
            {
                Items.Add(item);
            }
        }
        public void RemoveItem(int Id)
        {
            Items.RemoveAll(i => i.TicketId == Id);
        }
    }
}
