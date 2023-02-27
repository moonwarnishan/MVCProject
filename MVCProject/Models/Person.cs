using System.ComponentModel.DataAnnotations;

namespace SimpleMVCProject.Models
{
    public class Person
    {
        [Key]
        public Guid Key { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string MaritalStatus { get; set; }
        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
