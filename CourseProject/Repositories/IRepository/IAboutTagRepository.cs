using CourseProject.Models.Entity;

namespace CourseProject.Repositories.IRepository
{
    public interface IAboutTagRepository
    {
        Task<IEnumerable<AboutTag>> GetAllAsync();
        Task<AboutTag?> GetAsync(int id);
        Task<AboutTag?> UpdateAsync(AboutTag aboutTag);
    }
}
