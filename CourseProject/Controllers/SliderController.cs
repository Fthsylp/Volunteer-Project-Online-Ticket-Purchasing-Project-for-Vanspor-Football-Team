using CourseProject.Models.Entity;
using CourseProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class SliderController : Controller
    {
        private readonly ISliderItemRepository _sliderItemRepository;

        public SliderController(ISliderItemRepository sliderItemRepository)
        {
            _sliderItemRepository = sliderItemRepository;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _sliderItemRepository.GetAllAsync();
            return View(values);
        }
        public IActionResult AddSlider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSlider(SliderItem sliderItem)
        {
            if (HttpContext.Request.Form.Files.Count != 0)
            {
                IFormFile file = HttpContext.Request.Form.Files[0];
                string filename = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                string imgFilePath = Path.Combine("wwwroot", "sliderImage", filename + extension);

                using (FileStream stream = new FileStream(imgFilePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                sliderItem.Image = "/sliderImage/" + filename + extension;
            }
            sliderItem.Date = DateTime.Now;
            await _sliderItemRepository.AddAsync(sliderItem);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> EditSlider(int id)
        {
            var existingSlider = await _sliderItemRepository.GetAsync(id);
            return View(existingSlider);
        }
        [HttpPost]
        public async Task<IActionResult> EditSlider(SliderItem sliderItem)
        {
            if (HttpContext.Request.Form.Files.Count != 0 && !string.IsNullOrEmpty(HttpContext.Request.Form.Files[0].FileName))
            {
                IFormFile file = HttpContext.Request.Form.Files[0];
                string filename = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                string imgFilePath = Path.Combine("wwwroot", "sliderImage", filename + extension);

                using (FileStream stream = new FileStream(imgFilePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                sliderItem.Image = "/sliderImage/" + filename + extension;
            }
            sliderItem.Date = DateTime.Now;
            await _sliderItemRepository.UpdateAsync(sliderItem);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteSlider(int id)
        {
            await _sliderItemRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}

