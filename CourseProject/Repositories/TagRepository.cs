using CourseProject.Models.Data;
using CourseProject.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly TicketApplicationContext _ticketApplicationContext;

        public TagRepository(TicketApplicationContext ticketApplicationContext)
        {
            _ticketApplicationContext = ticketApplicationContext;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await _ticketApplicationContext.Tags.ToListAsync();
        }

        public Task<Tag?> GetAsync(int id)
        {
            return _ticketApplicationContext.Tags.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await _ticketApplicationContext.Tags.FindAsync(tag.Id);

            if (existingTag != null)
            {
                existingTag.FirstTitle = tag.FirstTitle;
                existingTag.SecondTitle = tag.SecondTitle;
                existingTag.Date = tag.Date;

                _ticketApplicationContext.Entry(existingTag).State = EntityState.Modified;
                await _ticketApplicationContext.SaveChangesAsync();
                return existingTag;
            }
            return null;
        }
    }
}
