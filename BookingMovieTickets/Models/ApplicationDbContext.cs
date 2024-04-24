using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.Models;

namespace BookingMovieTickets.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmCategory> FilmCategories { get; set; }

        public DbSet<FilmSchedule> FilmSchedules { get; set; }
        public DbSet<PremiereTime> PremiereTimes { get; set; }
        public DbSet<TheatreRoom> Rooms { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketDetail> ticketDetails { get; set; }
        //public DbSet<Combo> Combos { get; set; }

    }
}
