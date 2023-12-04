using CourseProject.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.ViewComponents.AboutPageComponents
{
    public class AboutTagComponent : ViewComponent
    {
        private readonly IAboutTagRepository _aboutTagRepository;

        public AboutTagComponent(IAboutTagRepository aboutTagRepository)
        {
            _aboutTagRepository = aboutTagRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _aboutTagRepository.GetAllAsync();
            return View(value);
        }
    }
}
