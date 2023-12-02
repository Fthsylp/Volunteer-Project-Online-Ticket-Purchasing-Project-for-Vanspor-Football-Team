using System.ComponentModel.DataAnnotations;

namespace CourseProject.Models.Entity
{
    public class ContactDetail {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? SecondTitle { get; set; }
        public string? Description { get; set; }
        public string? ButtonName {  get; set; }
        public string? PhoneNumber { get; set;}
        public string? EmailAdress { get; set;}
        public string? Adress { get; set; }
    }
}
