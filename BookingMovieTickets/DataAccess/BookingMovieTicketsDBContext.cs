using BookingMovieTickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.Models;

namespace MoviesBooking.DataAccess
{
    public class BookingMovieTicketsDBContext : IdentityDbContext<UserInfo>
    {
        public BookingMovieTicketsDBContext(DbContextOptions<BookingMovieTicketsDBContext> options) : base(options) 
        { 
        }


        public DbSet<UserInfo> Users { get; set; }
        public DbSet<TicketCart> TicketCarts { get; set; }
        public DbSet<TicketCartDetail> TicketCartDetails { get; set; }
        public DbSet<TheatreRoom> TheatreRooms { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; } // Renamed Ticket to Tickets for consistency
        public DbSet<TicketDetail> TicketDetails { get; set; }
        public DbSet<FilmCategory> FilmCategory { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmSchedule> FilmSchedules { get; set; } // Renamed FilmsSchedule to FilmSchedules
        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<Receipt> Receipts { get; set; } // Renamed Receipt to Receipts for consistency
        public DbSet<ReceiptDetail> ReceiptDetails { get; set; } // Renamed ReceiptDetail to ReceiptDetails

        //public DbSet<Combo> Combos { get; set; }
    }
}
