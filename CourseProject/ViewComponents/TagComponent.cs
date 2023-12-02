﻿using CourseProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.ViewComponents
{
    public class TagComponent : ViewComponent
    {
        private readonly ITagRepository _tagRepository;

        public TagComponent(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _tagRepository.GetAllAsync();
            return View(values);
        }
    }
}
