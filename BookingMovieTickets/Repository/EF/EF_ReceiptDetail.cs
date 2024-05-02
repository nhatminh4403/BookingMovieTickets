using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.DataAccess;

namespace BookingMovieTickets.Repository.EF
{
    public class EF_ReceiptDetail : I_ReceiptDetail
    {
        private readonly BookingMovieTicketsDBContext _context;
        public EF_ReceiptDetail(BookingMovieTicketsDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ReceiptDetail>> GetAllAsync()
        {
            return await _context.ReceiptDetails.Include(p=>p.Receipt).Include(p=>p.Ticket)
                .ToListAsync();
        }
        public async Task<ReceiptDetail> GetByIdAsync(int id)
        {
            return await _context.ReceiptDetails.Include(p => p.Receipt).Include(p => p.Ticket)
                .FirstAsync(p=>p.ReceiptDetailId==id);
        }
    }
}
