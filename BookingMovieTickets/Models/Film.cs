using BookingMovieTickets.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesBooking.Models
{
    public class Film
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Mã phim")]
        public int FilmId { get; set; }
        [Required]
        public string NameFilm{ get; set; }
        [Required]
        public string Description { get; set; }
        public string? PosterUrl { get; set; }

        public string? TrailerUrl { get; set; }
        [Required]
        public string DirectorName { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public string FilmRated { get; set; }
        [Required]
        public int FilmDuration { get; set; }
        [Required]
        public string Actors { get; set; }
        [Required]
        public int FilmCategoryId { get; set; }
        [Required]
        [DisplayName("Giờ chiếu")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        [ForeignKey("FilmCategoryId")]
        public virtual FilmCategory? FilmCategory { get; set; }
    
        public virtual ICollection<FilmSchedule>? FilmSchedules { get; set;}
    }
}
