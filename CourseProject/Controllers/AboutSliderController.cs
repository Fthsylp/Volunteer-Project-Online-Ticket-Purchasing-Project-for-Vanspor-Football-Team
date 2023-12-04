using CourseProject.Models.Entity;
using CourseProject.Repositories.IRepository;
using CourseProject.Repositories.Repository;
using Microsoft.AspNetCore.Mvc;


namespace CourseProject.Controllers
{
    public class AboutSliderController : Controller
    {
        private readonly IAboutSliderRepository _aboutSliderRepository;

        public AboutSliderController(IAboutSliderRepository aboutSliderRepository)
        {
            _aboutSliderRepository = aboutSliderRepository;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _aboutSliderRepository.GetAllAsync();
            return View(values);
        }
        public IActionResult AddAboutSlider() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAboutSlider(AboutSlider aboutSlider)
        {
            if (HttpContext.Request.Form.Files.Count != 0)
            {
                IFormFile file = HttpContext.Request.Form.Files[0];
                string filename = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                string imgFilePath = Path.Combine("wwwroot", "aboutSliderImage", filename + extension);

                using (FileStream stream = new FileStream(imgFilePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                aboutSlider.Image = "/aboutSliderImage/" + filename + extension;
            }
            await _aboutSliderRepository.AddAsync(aboutSlider);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> EditAboutSlider(int id) 
        { 
            var existingSlider = await _aboutSliderRepository.GetAsync(id);
            return View(existingSlider);
        }
        [HttpPost]
        public async Task<IActionResult> EditAboutSlider(AboutSlider aboutSlider) 
        {
            if (HttpContext.Request.Form.Files.Count != 0 && !string.IsNullOrEmpty(HttpContext.Request.Form.Files[0].FileName))
            {
                IFormFile file = HttpContext.Request.Form.Files[0];
                string filename = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                string imgFilePath = Path.Combine("wwwroot", "aboutSliderImage", filename + extension);

                using (FileStream stream = new FileStream(imgFilePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                aboutSlider.Image = "/aboutSliderImage/" + filename + extension;
            }
            await _aboutSliderRepository.UpdateAsync(aboutSlider);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteAboutSlider(int id) 
        {
            await _aboutSliderRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
