using CourseProject.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.ViewComponents.AboutPageComponents
{
    public class AboutSliderComponent : ViewComponent
    {
        private readonly IAboutSliderRepository _aboutSliderRepository;

        public AboutSliderComponent(IAboutSliderRepository aboutSliderRepository)
        {
            _aboutSliderRepository = aboutSliderRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var value = await _aboutSliderRepository.GetAllAsync();
            return View(value);
        }
    }
}
