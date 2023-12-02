using CourseProject.Models.Entity;

namespace CourseProject.Repositories
{
    public interface IMatchDetailsRepository
    {
        Task<IEnumerable<MatchDetail>> GetAllAsync();
        Task<MatchDetail?> GetAsync(int id);
        Task<MatchDetail?> AddAsync(MatchDetail matchDetail);
        Task<MatchDetail?> UpdateAsync(MatchDetail matchDetail);
        Task<MatchDetail?> DeleteAsync(int id);
        Task<BuyTicket> BuyAsync (BuyTicket buyTicket);
    }
}
