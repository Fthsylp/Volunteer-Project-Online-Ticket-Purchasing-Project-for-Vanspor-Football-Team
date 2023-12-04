using CourseProject.Migrations;
using CourseProject.Models.Data;
using CourseProject.Models.Entity;
using CourseProject.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Repositories.Repository
{
    public class AboutSliderRepository : IAboutSliderRepository
    {
        private readonly TicketApplicationContext _ticketApplicationContext;

        public AboutSliderRepository(TicketApplicationContext ticketApplicationContext)
        {
            _ticketApplicationContext = ticketApplicationContext;
        }

        public async Task<AboutSlider?> AddAsync(AboutSlider aboutSlider)
        {
            await _ticketApplicationContext.AboutSliders.AddAsync(aboutSlider);
            await _ticketApplicationContext.SaveChangesAsync();
            return aboutSlider;
        }

        public async Task<AboutSlider?> DeleteAsync(int id)
        {
            var existingAboutSlider = await _ticketApplicationContext.AboutSliders.FindAsync(id);
            if (existingAboutSlider != null) 
            {
                _ticketApplicationContext.AboutSliders.Remove(existingAboutSlider);
                await _ticketApplicationContext.SaveChangesAsync();
                return existingAboutSlider;
            }
            return null;
        }

        public async Task<IEnumerable<AboutSlider>> GetAllAsync()
        {
            return await _ticketApplicationContext.AboutSliders.ToListAsync();
        }

        public Task<AboutSlider?> GetAsync(int id)
        {
            return _ticketApplicationContext.AboutSliders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AboutSlider?> UpdateAsync(AboutSlider aboutSlider)
        {
            var existingSlider = await _ticketApplicationContext.AboutSliders.FindAsync(aboutSlider.Id);
            if (existingSlider != null) 
            {
                existingSlider.Title = aboutSlider.Title;
                existingSlider.Image = aboutSlider.Image;
                existingSlider.Date = aboutSlider.Date;
                existingSlider.SecondTitle = aboutSlider.SecondTitle;
                existingSlider.Paragraph1 = aboutSlider.Paragraph1;
                existingSlider.Paragraph2 = aboutSlider.Paragraph2;
                existingSlider.Paragraph3 = aboutSlider.Paragraph3;
                existingSlider.Paragraph4 = aboutSlider.Paragraph4;

                await _ticketApplicationContext.SaveChangesAsync();
                return existingSlider;
            }
            return null;
        }
    }
}
