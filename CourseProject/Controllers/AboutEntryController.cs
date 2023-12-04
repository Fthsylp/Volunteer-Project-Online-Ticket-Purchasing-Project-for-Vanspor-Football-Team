using CourseProject.Models.Entity;
using CourseProject.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class AboutEntryController : Controller
    {
        private readonly IAboutEntryRepository _aboutEntryRepository;

        public AboutEntryController(IAboutEntryRepository aboutEntryRepository)
        {
            _aboutEntryRepository = aboutEntryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _aboutEntryRepository.GetAsync(1);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AboutEntry aboutEntry) 
        {
            if (HttpContext.Request.Form.Files.Count != 0 && !string.IsNullOrEmpty(HttpContext.Request.Form.Files[0].FileName))
            {
                IFormFile file = HttpContext.Request.Form.Files[0];
                string filename = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                string imgFilePath = Path.Combine("wwwroot", "aboutEntryImage", filename + extension);

                using (FileStream stream = new FileStream(imgFilePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                aboutEntry.Image = "/aboutEntryImage/" + filename + extension;
            }
            await _aboutEntryRepository.UpdateAsync(aboutEntry);
            return RedirectToAction("Index");
        }
    }
}
