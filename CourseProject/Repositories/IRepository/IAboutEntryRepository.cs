using CourseProject.Models.Entity;

namespace CourseProject.Repositories.IRepository
{
    public interface IAboutEntryRepository
    {
        Task<IEnumerable<AboutEntry>> GetAllAsync();
        Task<AboutEntry?> GetAsync(int id);
        Task<AboutEntry?> UpdateAsync(AboutEntry aboutEntry);
    }
}
