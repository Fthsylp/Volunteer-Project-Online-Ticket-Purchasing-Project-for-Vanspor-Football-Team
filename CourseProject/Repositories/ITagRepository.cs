using CourseProject.Models.Entity;

namespace CourseProject.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllAsync();
        Task<Tag?> GetAsync(int id);
        Task<Tag?> UpdateAsync(Tag tag);
    }
}
