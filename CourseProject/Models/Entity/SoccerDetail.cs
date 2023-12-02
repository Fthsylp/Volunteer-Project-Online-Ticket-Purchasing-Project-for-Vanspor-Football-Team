using System.ComponentModel.DataAnnotations;

namespace CourseProject.Models.Entity
{
    public class SoccerDetail
    {
        [Key]
        public int Id { get; set; }
        public string? Name {  get; set; }
        public string? Image { get; set; }
    }
}
