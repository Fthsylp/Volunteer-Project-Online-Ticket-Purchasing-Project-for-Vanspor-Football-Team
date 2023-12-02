using System.ComponentModel.DataAnnotations;

namespace CourseProject.Models.Entity
{
    public class BuyTicket
    {
        [Key]
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public int TicketCount { get; set; }
        public int PaidPrice { get; set; }
        public DateTime Date { get; set; }

        //public int MatchDetailId { get; set; }
        //public MatchDetail? MatchDetail { get; set; }
    }
}
