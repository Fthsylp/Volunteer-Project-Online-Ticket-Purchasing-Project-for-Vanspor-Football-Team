using CourseProject.Models.Entity;
using CourseProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class MatchDetailsController : Controller
    {
        private readonly IMatchDetailsRepository _matchDetailsRepository;

        public MatchDetailsController(IMatchDetailsRepository matchDetailsRepository)
        {
            _matchDetailsRepository = matchDetailsRepository;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _matchDetailsRepository.GetAllAsync();
            return View(values);
        }
        public IActionResult AddMatch() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddMatch(MatchDetail matchDetail) 
        { 
            if(HttpContext.Request.Form.Files.Count != 0)
            {
                IFormFile file = HttpContext.Request.Form.Files[0];
                string filename = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                string imgFilePath = Path.Combine("wwwroot", "matchImage", filename + extension);

                using (FileStream stream = new FileStream(imgFilePath, FileMode.Create)) 
                {
                    file.CopyTo(stream);
                }
                matchDetail.MatchImage = "/matchImage/" + filename + extension;
            }
            await _matchDetailsRepository.AddAsync(matchDetail);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> EditMatch(int id) 
        {
            var existingMatch = await _matchDetailsRepository.GetAsync(id);
            return View(existingMatch);
        }
        [HttpPost]
        public async Task<IActionResult> EditMatch(MatchDetail matchDetail) 
        {
            if (HttpContext.Request.Form.Files.Count != 0 && !string.IsNullOrEmpty(HttpContext.Request.Form.Files[0].FileName))
            {
                IFormFile file = HttpContext.Request.Form.Files[0];
                string filename = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                string imgFilePath = Path.Combine("wwwroot", "matchImage", filename + extension);

                using (FileStream stream = new FileStream(imgFilePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                matchDetail.MatchImage = "/matchImage/" + filename + extension;
            }
            await _matchDetailsRepository.UpdateAsync(matchDetail);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteMatch(int id) 
        {
            await _matchDetailsRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
