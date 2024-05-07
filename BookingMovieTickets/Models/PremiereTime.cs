using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesBooking.Models
{
    public class PremiereTime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PremiereTimeId { get; set; }
        [Required]
        [DisplayName("Giờ chiếu")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        public virtual Film Film { get; set; }
    }
}
