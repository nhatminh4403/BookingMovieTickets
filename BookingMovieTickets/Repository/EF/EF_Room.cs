using BookingMovieTickets.DataAccess;
using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.Interface;
using Microsoft.EntityFrameworkCore;
namespace BookingMovieTickets.Repository.EF
{
    public class EF_Room : I_TheatreRoom
    {
        private readonly BookingMovieTicketsDBContext _dbContext;
        public EF_Room(BookingMovieTicketsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TheatreRoom>> GetAllRoomAsync()
        {
            return await _dbContext.TheatreRooms.Include(p=>p.Theatre).Include(p => p.FilmSchedules).ToListAsync();
        }
        public async Task<TheatreRoom> GetByIdAsync(int id)
        {
            return await _dbContext.TheatreRooms.Include(p => p.Theatre).Include(p=>p.FilmSchedules).FirstAsync(i => i.TheatreRoomId == id);
        }
        public async Task AddAsync(TheatreRoom theatreRoom)
        {
            _dbContext.TheatreRooms.Add(theatreRoom);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(TheatreRoom theatreRoom)
        {
            _dbContext.TheatreRooms.Update(theatreRoom);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var room = await _dbContext.TheatreRooms.FindAsync(id);
            if (room != null)
            {
                _dbContext.TheatreRooms.Remove(room);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
