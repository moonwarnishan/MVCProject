using MVCProject.Domains;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVCProject.Models
{
    public class PersonsInfoLanguagesModel
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
        [Required, DisplayName("Marital Status")]
        public string MaritalStatusInString { get; set; }
        [Required, DisplayName("Gender")]
        public string GenderInString { get; set; }

        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public Guid LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
