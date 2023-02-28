using System.ComponentModel.DataAnnotations;

namespace MVCProject.Domains
{
    public class Language
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<PersonsInfoLanguages>? PersonInfoDifferentLanguage { get; set; }
    }
}
