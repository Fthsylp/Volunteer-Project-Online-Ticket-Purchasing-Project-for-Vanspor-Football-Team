using CourseProject.Repositories.IRepository;
using CourseProject.ViewComponents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    [AllowAnonymous]
    public class ContactPageController : Controller
    {
        private readonly IContactDetailsRepository _contactDetailsRepository;

        public ContactPageController(IContactDetailsRepository contactDetailsRepository)
        {
            _contactDetailsRepository = contactDetailsRepository;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _contactDetailsRepository.GetAllAsync();
            return View(values);
        }
    }
}
