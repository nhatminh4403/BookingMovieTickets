﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingMovieTickets.Models
{
    public class Theatre
    {
        [DisplayName("Mã rạp")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TheatreId { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Địa chỉ rạp")]
        [Required]
        public string Location { get; set; }
        public virtual ICollection<TheatreRoom> TheatreRooms { get; set; }
    }
}
