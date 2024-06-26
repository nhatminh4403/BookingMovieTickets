﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingMovieTickets.Models
{
    public class TicketCart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual UserInfo UserInfo { get; set; }
        [NotMapped]
        public List<TicketCartDetail> Items { get; set; } = new List<TicketCartDetail>();
        public void AddOrRemoveItem(TicketCartDetail item)
        {
            var existingItem = Items.FirstOrDefault(i => i.FilmId == item.FilmId &&
                                                  i.SeatId == item.SeatId &&
                                                  i.FilmScheduleId == item.FilmScheduleId &&
                                                    i.FilmScheduleDescriptionID == item.FilmScheduleDescriptionID);

            if (existingItem != null)
            {
                Items.Remove(existingItem);
            }
            else
            {
                Items.Add(item);
            }
        }
        public void RemoveItem(int filmID, int time, int seatID)
        {
            Items.RemoveAll(i => i.SeatId==seatID && i.FilmId == filmID && i.FilmScheduleId==time);
        }
    }
}
