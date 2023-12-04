using CourseProject.Models.Entity;

namespace CourseProject.Repositories.IRepository
{
    public interface IContactDetailsRepository
    {
        Task<IEnumerable<ContactDetail>> GetAllAsync();
        Task<ContactDetail?> GetAsync(int id);
        Task<ContactDetail?> UpdateAsync(ContactDetail contactDetail);
    }
}
