using CourseProject.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Data
{
    public class TicketApplicationContext : DbContext
    {
        public TicketApplicationContext(DbContextOptions<TicketApplicationContext> options) : base(options)
        {
        }
        public DbSet<SliderItem> SliderItems { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<MatchDetail> MatchDetails { get; set; }
        public DbSet<SoccerDetail> SoccerDetails { get; set; }
        public DbSet<BuyTicket> BuyTickets { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<AboutEntry> AboutEntries { get; set; }
        public DbSet<AboutTag> AboutTags { get; set; }
        public DbSet<AboutSlider> AboutSliders { get; set; }
    }
}
