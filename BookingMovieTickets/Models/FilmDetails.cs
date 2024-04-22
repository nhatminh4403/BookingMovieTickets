using MoviesBooking.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingMovieTickets.Models
{
    public class FilmDetails
    {
        [Key]
        [ForeignKey("Film")]
        public int FilmId { get; set; }

        [Required]
        public string DirectorName { get; set; }
        [Required]
        public string Language {  get; set; }
        [Required]
        public string FilmRated { get; set; }
        [Required]
        public int FilmDuration { get; set; }
        [Required]
        public string Actors { get; set; }
        public virtual Film Film { get; set; }
    }
}
