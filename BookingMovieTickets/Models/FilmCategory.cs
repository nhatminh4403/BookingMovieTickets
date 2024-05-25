using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingMovieTickets.Models
{
    public class FilmCategory
    {
        [Key]
        [Required]
        [DisplayName("Mã loại phim")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FilmCategoryId { get; set; }
        [Required]
        [DisplayName("Tên")]
        public string Name { get; set; }
        public virtual ICollection<Film>? Film { get; set; }
    }
}
