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
        public int FilmScheduleId { get; set; }
        public int TicketId { get; set; }
        public int SeatId { get; set; }
        public decimal Price { get; set; }
        // Other properties as needed
        public virtual Seat Seat { get; set; }
        public virtual Receipt Receipt { get; set; }
        public virtual FilmSchedule FilmSchedule { get; set; }
        public virtual Ticket Ticket { get; set; }
    }

}
