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
        [Required]
        public string PosterUrl { get; set; }
        [Required]
        public string TrailerUrl { get; set; }
        [Required]
        public DateTime PremiereDate { get; set; }
        public virtual ICollection<FilmCategory>? FilmCategory { get; set; }
        public virtual FilmDetails? FilmDetails { get; set; }
        public virtual ICollection<PremiereTime> PremiereTimes { get; set; }
        public virtual ICollection<FilmSchedule> FilmSchedules { get; set;}
    }
}
