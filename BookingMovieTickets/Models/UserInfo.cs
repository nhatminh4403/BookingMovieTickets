
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookingMovieTickets.Models
{
    public class UserInfo : IdentityUser
    {
        [Required]
        [StringLength(50)]
        [DisplayName("Họ và tên")]
        public string FullName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }
        public virtual TicketCart TicketCart { get; set; }
    }
}
