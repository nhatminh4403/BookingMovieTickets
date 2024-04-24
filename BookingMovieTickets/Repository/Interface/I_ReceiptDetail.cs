using BookingMovieTickets.Models;
using MoviesBooking.Models;

namespace BookingMovieTickets.Repository.Interface
{
    public interface I_ReceiptDetail
    {
        Task<IEnumerable<ReceiptDetail>> GetAllAsync();
        Task<ReceiptDetail> GetByIdAsync(int id);
    }
}
