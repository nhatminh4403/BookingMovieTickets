using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesBooking.Models
{
    public class TheatreRoom
    {
        [DisplayName("Mã phòng")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int TheatreRoomId { get; set; }
        [Required]
        public int TheatreId { get; set; }
        [Required]
        [DisplayName("Tên phòng")]
        public string RoomName { get; set; }
        // Other properties as needed
        [ForeignKey("TheatreId")]
        public virtual Theatre Theatre { get; set; }
        public virtual ICollection<FilmSchedule>? FilmSchedules { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
