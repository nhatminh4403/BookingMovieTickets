using MoviesBooking.Models;


namespace BookingMovieTickets.Repository.Interface
{
    public interface I_ScheduleDescription
    {
        Task<IEnumerable<ScheduleDescription>> GetAllAsync();
        Task<ScheduleDescription> GetByIdAsync(int id);
        Task<ScheduleDescription> GetScreentimeByTimeAsync(TimeSpan screenTime);
    }
}
