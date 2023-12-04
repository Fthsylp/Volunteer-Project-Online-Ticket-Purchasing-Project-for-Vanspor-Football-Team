using CourseProject.Models.Data;
using CourseProject.Models.Entity;
using CourseProject.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Repositories.Repository
{
    public class AboutEntryRepository : IAboutEntryRepository
    {
        private readonly TicketApplicationContext _ticketApplicationContext;

        public AboutEntryRepository(TicketApplicationContext ticketApplicationContext)
        {
            _ticketApplicationContext = ticketApplicationContext;
        }

        public async Task<IEnumerable<AboutEntry>> GetAllAsync()
        {
            return await _ticketApplicationContext.AboutEntries.ToListAsync();
        }

        public Task<AboutEntry?> GetAsync(int id)
        {
            return _ticketApplicationContext.AboutEntries.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AboutEntry?> UpdateAsync(AboutEntry aboutEntry)
        {
            var existingEntry = await _ticketApplicationContext.AboutEntries.FindAsync(aboutEntry.Id);
            if (existingEntry != null)
            {
                existingEntry.FirstTitle = aboutEntry.FirstTitle;
                existingEntry.SecondTitle = aboutEntry.SecondTitle;
                existingEntry.Image = aboutEntry.Image;
                existingEntry.Description = aboutEntry.Description;

                await _ticketApplicationContext.SaveChangesAsync();
                return existingEntry;
            }
            return null;
        }
    }
}
