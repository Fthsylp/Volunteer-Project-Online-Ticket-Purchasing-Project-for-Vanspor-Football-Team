using CourseProject.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.ViewComponents.AboutPageComponents
{
    public class AboutEntryComponent : ViewComponent
    {
        private readonly IAboutEntryRepository _aboutEntryRepository;

        public AboutEntryComponent(IAboutEntryRepository aboutEntryRepository)
        {
            _aboutEntryRepository = aboutEntryRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var value = await _aboutEntryRepository.GetAllAsync();
            return View(value);
        }
    }
}
