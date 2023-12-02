using CourseProject.Models.Entity;
using CourseProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagRepository _tagRepository;

        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _tagRepository.GetAsync(1);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Tag tag)
        {
            tag.Date = DateTime.Now;
            await _tagRepository.UpdateAsync(tag);
            return RedirectToAction("Index");
        }

    }
}
