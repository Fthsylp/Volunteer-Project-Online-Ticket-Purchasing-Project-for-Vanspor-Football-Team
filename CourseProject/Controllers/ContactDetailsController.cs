using CourseProject.Models.Entity;
using CourseProject.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class ContactDetailsController : Controller
    {
        private readonly IContactDetailsRepository _contactDetailsRepository;

        public ContactDetailsController(IContactDetailsRepository contactDetailsRepository)
        {
            _contactDetailsRepository = contactDetailsRepository;
        }
        public async Task<IActionResult> Index()
        {
            var value = await _contactDetailsRepository.GetAsync(1);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> Index(ContactDetail contactDetail)
        {
            await _contactDetailsRepository.UpdateAsync(contactDetail);
            return RedirectToAction("Index");
        }
    }
}
