using BookingMovieTickets.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MoviesBooking.Models
{
    public class UserInfo : IdentityUser
    {
        [Required]
        [StringLength(50)]
        [DisplayName("Tên")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Họ")]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
        public virtual TicketCart TicketCart { get; set; }
    }
}
