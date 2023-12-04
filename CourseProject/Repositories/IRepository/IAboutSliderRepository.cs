using CourseProject.Migrations;
using CourseProject.Models.Entity;

namespace CourseProject.Repositories.IRepository
{
    public interface IAboutSliderRepository
    {
        Task<IEnumerable<AboutSlider>> GetAllAsync();
        Task<AboutSlider?> GetAsync(int id);
        Task<AboutSlider?> AddAsync(AboutSlider aboutSlider);
        Task<AboutSlider?> UpdateAsync(AboutSlider aboutSlider);
        Task<AboutSlider?> DeleteAsync(int id);
    }
}
