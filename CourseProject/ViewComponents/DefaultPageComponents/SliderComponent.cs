using CourseProject.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.ViewComponents.DefaultPageComponents
{
    public class SliderComponent : ViewComponent
    {
        private readonly ISliderItemRepository _sliderItemRepository;

        public SliderComponent(ISliderItemRepository sliderItemRepository)
        {
            _sliderItemRepository = sliderItemRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _sliderItemRepository.GetAllAsync();
            return View(values);
        }
    }
}
