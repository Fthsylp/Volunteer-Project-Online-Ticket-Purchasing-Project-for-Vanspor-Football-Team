using CourseProject.Models.Entity;

namespace CourseProject.Repositories.IRepository
{
    public interface ISoccerDetailsRepository
    {
        Task<IEnumerable<SoccerDetail>> GetAllAsync();
        Task<SoccerDetail?> GetAsync(int id);
        Task<SoccerDetail?> AddAsync(SoccerDetail soccerDetail);
        Task<SoccerDetail?> UpdateAsync(SoccerDetail soccerDetail);
        Task<SoccerDetail?> DeleteAsync(int id);
    }
}
