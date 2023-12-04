using CourseProject.Models.Data;
using CourseProject.Models.Entity;
using CourseProject.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Repositories.Repository
{
    public class MatchDetailsRepository : IMatchDetailsRepository
    {
        private readonly TicketApplicationContext _ticketApplicationContext;

        public MatchDetailsRepository(TicketApplicationContext ticketApplicationContext)
        {
            _ticketApplicationContext = ticketApplicationContext;
        }

        public async Task<MatchDetail?> AddAsync(MatchDetail matchDetail)
        {
            await _ticketApplicationContext.MatchDetails.AddAsync(matchDetail);
            await _ticketApplicationContext.SaveChangesAsync();
            return matchDetail;
        }

        public async Task<BuyTicket> BuyAsync(BuyTicket buyTicket)
        {
            await _ticketApplicationContext.BuyTickets.AddAsync(buyTicket);
            await _ticketApplicationContext.SaveChangesAsync();
            return buyTicket;
        }

        public async Task<MatchDetail?> DeleteAsync(int id)
        {
            var existingMatch = await _ticketApplicationContext.MatchDetails.FindAsync(id);
            if (existingMatch != null)
            {
                _ticketApplicationContext.MatchDetails.Remove(existingMatch);
                await _ticketApplicationContext.SaveChangesAsync();
                return existingMatch;
            }
            return null;
        }

        public async Task<IEnumerable<MatchDetail>> GetAllAsync()
        {
            return await _ticketApplicationContext.MatchDetails.ToListAsync();
        }

        public Task<MatchDetail?> GetAsync(int id)
        {
            return _ticketApplicationContext.MatchDetails.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MatchDetail?> UpdateAsync(MatchDetail matchDetail)
        {
            var existingMatch = await _ticketApplicationContext.MatchDetails.FindAsync(matchDetail.Id);
            if (existingMatch != null)
            {
                existingMatch.TicketPrice = matchDetail.TicketPrice;
                existingMatch.MatchDate = matchDetail.MatchDate;
                existingMatch.MatchImage = matchDetail.MatchImage;
                existingMatch.MatchDescription = matchDetail.MatchDescription;
                existingMatch.MatchType = matchDetail.MatchType;
                existingMatch.MatchTime = matchDetail.MatchTime;
                existingMatch.MatchName = matchDetail.MatchName;

                await _ticketApplicationContext.SaveChangesAsync();
                return existingMatch;
            }
            return null;
        }
    }
}
