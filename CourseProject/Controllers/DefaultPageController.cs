using CourseProject.Models.Entity;
using CourseProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    [AllowAnonymous]
    public class DefaultPageController : Controller
    {
        private readonly IMatchDetailsRepository _matchDetailsRepository;

        public DefaultPageController(IMatchDetailsRepository matchDetailsRepository)
        {
            _matchDetailsRepository = matchDetailsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ShowTicket(int id)
        {
            var ticketPage = await _matchDetailsRepository.GetAsync(id);
            ViewBag.MatchDetail = ticketPage;
            return View(ticketPage);
        }
        [HttpPost]
        public async Task<IActionResult> BuyTicket(BuyTicket buyTicket)
        {
            buyTicket.Date = DateTime.Now;
            await _matchDetailsRepository.BuyAsync(buyTicket);
            return Json(new { success = true, message = "Bilet alımı başarılı!" });
        }
    }
}
