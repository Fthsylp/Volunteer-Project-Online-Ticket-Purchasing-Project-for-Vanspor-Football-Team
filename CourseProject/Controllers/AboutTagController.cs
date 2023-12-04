using CourseProject.Models.Entity;
using CourseProject.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class AboutTagController : Controller
    {
        private readonly IAboutTagRepository _aboutTagRepository;

        public AboutTagController(IAboutTagRepository aboutTagRepository)
        {
            _aboutTagRepository = aboutTagRepository;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _aboutTagRepository.GetAsync(1);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AboutTag aboutTag)
        {
            await _aboutTagRepository.UpdateAsync(aboutTag);
            return RedirectToAction("Index");
        }
    }
}
