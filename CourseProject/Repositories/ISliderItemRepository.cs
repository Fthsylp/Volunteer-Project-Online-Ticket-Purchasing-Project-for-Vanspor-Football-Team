using CourseProject.Models.Entity;

namespace CourseProject.Repositories
{
    public interface ISliderItemRepository
    {
        Task<IEnumerable<SliderItem>> GetAllAsync();
        Task<SliderItem?> GetAsync(int id);
        Task<SliderItem?> AddAsync(SliderItem sliderItem);
        Task<SliderItem?> UpdateAsync(SliderItem sliderItem);
        Task<SliderItem?> DeleteAsync(int id);
    }
}
