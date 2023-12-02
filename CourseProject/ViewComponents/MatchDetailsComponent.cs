using CourseProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.ViewComponents
{
    public class MatchDetailsComponent : ViewComponent
    {
        private readonly IMatchDetailsRepository _matchDetailsRepository;

        public MatchDetailsComponent(IMatchDetailsRepository matchDetailsRepository)
        {
            _matchDetailsRepository = matchDetailsRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _matchDetailsRepository.GetAllAsync();
            return View(values);
        }
       
    }
}
