using System.ComponentModel.DataAnnotations;

namespace CourseProject.Models.Entity
{
    public class MatchDetail
    {
        [Key]
        public int Id { get; set; }
        public string? MatchName {  get; set; }
        public string? MatchDescription { get; set;}
        public string? MatchType { get; set;}
        public DateTime MatchDate { get; set; } // gün ay yıl
        public DateTime MatchTime { get; set; } // saat
        public string? MatchImage { get; set; }
        public int TicketPrice { get; set; }
    }
}
