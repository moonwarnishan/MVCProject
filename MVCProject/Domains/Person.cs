using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCProject.Domains
{
    public class Person
    {
        [Key]
        public Guid Key { get; set; }
        [Required, DisplayName("Name")]
        public string Name { get; set; } = string.Empty;
        [Required, DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int Gender { get; set; }
        [Required, DisplayName("Marital Status")]
        public int MaritalStatus { get; set; }
        [Required, DisplayName("Creation Date")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public List<PersonsInfoLanguages> PersonInfoLanguages { get; set; }
    }
}
