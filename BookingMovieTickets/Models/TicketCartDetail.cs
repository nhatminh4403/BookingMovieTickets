using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingMovieTickets.Models
{
    public class TicketCartDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartDetailId { get; set; }      
        public int FilmId { get; set; }

        [Required]
        public string FilmName { get; set; }

        [Required]
        public string? PosterUrl { get; set; }

        [Required]
        public decimal Price { get; set; }
        [Required]
        public int FilmScheduleId { get; set; }
        [Required]
        public string FilmScheduleDes { get; set; }
        [Required]
        public int FilmScheduleDescriptionID { get; set; }
        [Required]
        public int SeatId { get; set; }

        [Required]
        public string SeatNumber { get; set; }

        [Required]
        public string RoomName { get; set; }

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
