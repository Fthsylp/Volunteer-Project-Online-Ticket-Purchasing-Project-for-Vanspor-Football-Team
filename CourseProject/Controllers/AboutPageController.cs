using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    [AllowAnonymous]
    public class AboutPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
