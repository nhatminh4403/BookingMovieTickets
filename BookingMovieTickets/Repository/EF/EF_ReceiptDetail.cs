using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.DataAccess;

namespace BookingMovieTickets.Repository.EF
{
    public class EF_ReceiptDetail : I_ReceiptDetail
    {
        private readonly MoviesBookingDBContext _context;
        public EF_ReceiptDetail(MoviesBookingDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ReceiptDetail>> GetAllAsync()
        {
            return await _context.ReceiptDetail.Include(p=>p.Receipt).Include(p=>p.FilmSchedule).Include(p=>p.Seat).Include(p=>p.FilmSchedule)
                .ToListAsync();
        }
        public async Task<ReceiptDetail> GetByIdAsync(int id)
        {
            return await _context.ReceiptDetail.Include(p => p.Receipt).Include(p => p.FilmSchedule).Include(p => p.Seat).Include(p => p.FilmSchedule)
                .FirstAsync(p=>p.ReceiptDetailId==id);
        }
    }
}
