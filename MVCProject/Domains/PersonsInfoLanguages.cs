using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCProject.Domains
{
    public class PersonsInfoLanguages
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Required, DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int Gender { get; set; }
        [Required, DisplayName("Marital Status")]
        public int MaritalStatus { get; set; }

        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public Guid LanguageId { get; set; }
        public Language Language { get; set; }

    }
}
