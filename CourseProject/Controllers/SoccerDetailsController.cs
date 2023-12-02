using CourseProject.Models.Entity;
using CourseProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class SoccerDetailsController : Controller
    {
        private readonly ISoccerDetailsRepository _soccerDetailsRepository;

        public SoccerDetailsController(ISoccerDetailsRepository soccerDetailsRepository)
        {
            _soccerDetailsRepository = soccerDetailsRepository;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _soccerDetailsRepository.GetAllAsync();
            return View(values);
        }
        public IActionResult AddSoccer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSoccer(SoccerDetail soccerDetail) 
        {
            if (HttpContext.Request.Form.Files.Count != 0)
            {
                IFormFile file = HttpContext.Request.Form.Files[0];
                string filename = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                string imgFilePath = Path.Combine("wwwroot", "soccerImage", filename + extension);

                using (FileStream stream = new FileStream(imgFilePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                soccerDetail.Image = "/soccerImage/" + filename + extension;
            }
            await _soccerDetailsRepository.AddAsync(soccerDetail);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> EditSoccer(int id)
        {
            var existingSoccer = await _soccerDetailsRepository.GetAsync(id);
            return View(existingSoccer);
        }
        [HttpPost]
        public async Task<IActionResult> EditSoccer(SoccerDetail soccerDetail)
        {
            if(HttpContext.Request.Form.Files.Count != 0 && !string.IsNullOrEmpty(HttpContext.Request.Form.Files[0].FileName))
            {
                IFormFile file = HttpContext.Request.Form.Files[0];
                string filename = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                string imgFilePath = Path.Combine("wwwroot", "soccerImage", filename + extension);

                using (FileStream stream = new FileStream(imgFilePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                soccerDetail.Image = "/soccerImage/" + filename + extension;
            }
            await _soccerDetailsRepository.UpdateAsync(soccerDetail);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteSoccer(int id)
        {
            await _soccerDetailsRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
