using System.ComponentModel.DataAnnotations;

namespace CourseProject.Models.Entity
{
    public class Tag
    {
        //[Key]
        //public int Id { get; set; }
        //public string? Title { get; set; }
        //public string? Description { get; set; }
        //public string? Image {  get; set; }

        [Key]
        public int Id { get; set; }
        public string? FirstTitle { get; set; }
        public string? SecondTitle { get; set; }
        public DateTime Date { get; set; }
    }
}
