﻿using MoviesBooking.Models;
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
        [ForeignKey("Ticket")]
        [Required]
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public virtual Receipt Receipt { get; set; }
    }

}