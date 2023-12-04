using CourseProject.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    [AllowAnonymous]
    public class SoccerPageController : Controller
    {
        private readonly ISoccerDetailsRepository _soccerDetailsRepository;
        public SoccerPageController(ISoccerDetailsRepository soccerDetailsRepository)
        {
            _soccerDetailsRepository = soccerDetailsRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _soccerDetailsRepository.GetAllAsync();
            return View(values);
        }
    }
}
