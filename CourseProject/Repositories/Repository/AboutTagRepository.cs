using CourseProject.Models.Data;
using CourseProject.Models.Entity;
using CourseProject.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Repositories.Repository
{
    public class AboutTagRepository : IAboutTagRepository
    {
        private readonly TicketApplicationContext _ticketApplicationContext;

        public AboutTagRepository(TicketApplicationContext ticketApplicationContext)
        {
            _ticketApplicationContext = ticketApplicationContext;
        }

        public async Task<IEnumerable<AboutTag>> GetAllAsync()
        {
            return await _ticketApplicationContext.AboutTags.ToListAsync();
        }

        public Task<AboutTag?> GetAsync(int id)
        {
            return _ticketApplicationContext.AboutTags.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AboutTag?> UpdateAsync(AboutTag aboutTag)
        {
            var existingTag = await _ticketApplicationContext.AboutTags.FindAsync(aboutTag.Id);
            if (existingTag != null) 
            {
                existingTag.Title = aboutTag.Title;
                existingTag.Description = aboutTag.Description;

                await _ticketApplicationContext.SaveChangesAsync();
                return existingTag;
            }
            return null;
        }
    }
}
