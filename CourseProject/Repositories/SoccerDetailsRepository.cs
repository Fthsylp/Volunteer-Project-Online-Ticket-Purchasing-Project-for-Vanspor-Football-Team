using CourseProject.Models.Data;
using CourseProject.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Repositories
{
    public class SoccerDetailsRepository : ISoccerDetailsRepository
    {
        private readonly TicketApplicationContext _ticketApplicationContext;

        public SoccerDetailsRepository(TicketApplicationContext ticketApplicationContext)
        {
            _ticketApplicationContext = ticketApplicationContext;
        }

        public async Task<SoccerDetail?> AddAsync(SoccerDetail soccerDetail)
        {
            await _ticketApplicationContext.SoccerDetails.AddAsync(soccerDetail);
            await _ticketApplicationContext.SaveChangesAsync();
            return soccerDetail;
        }

        public async Task<SoccerDetail?> DeleteAsync(int id)
        {
            var existingSoccer = await _ticketApplicationContext.SoccerDetails.FindAsync(id);
            if (existingSoccer != null)
            {
                _ticketApplicationContext.SoccerDetails.Remove(existingSoccer);
                await _ticketApplicationContext.SaveChangesAsync();
                return existingSoccer;
            }
            return null;
        }

        public async Task<IEnumerable<SoccerDetail>> GetAllAsync()
        {
            return await _ticketApplicationContext.SoccerDetails.ToListAsync();
        }

        public Task<SoccerDetail?> GetAsync(int id)
        {
            return _ticketApplicationContext.SoccerDetails.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<SoccerDetail?> UpdateAsync(SoccerDetail soccerDetail)
        {
            var existingSoccer = await _ticketApplicationContext.SoccerDetails.FindAsync(soccerDetail.Id);
            if (existingSoccer != null)
            {
                existingSoccer.Name = soccerDetail.Name;
                existingSoccer.Image = soccerDetail.Image;
                await _ticketApplicationContext.SaveChangesAsync();
                return existingSoccer;
            }
            return null;
        }
    }
}
