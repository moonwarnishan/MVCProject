using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class PersonLanguageModel
    {
        public PersonLanguageModel()
        {
            Languages = new List<SelectListItem>();
            Persons= new List<SelectListItem>();
            Genders= new List<SelectListItem>();
            MaritalStatuses = new List<SelectListItem>();
        }
        [Key]
        public Guid Id { get; set; }
        [DisplayName("Language Name")]
        public Guid LanguageId { get; set; }
        [DisplayName("Person Name")]
        public Guid PersonId { get; set; }
        public string Name { get; set; } = string.Empty;
        [Required, DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int Gender { get; set; }
        [Required, DisplayName("Gender")]
        public string? GenderInString { get; set; }
        [Required, DisplayName("Marital Status")]
        public int MaritalStatus { get; set; }
        [Required, DisplayName("Marital Status")]
        public string? MaritalStatusInString { get; set; }
        [Required, DisplayName("Languages")]
        public List<SelectListItem> Languages { get; set; }
        [Required, DisplayName("Persons")]
        public List<SelectListItem> Persons { get; set; }
        [Required, DisplayName("Genders")]
        public List<SelectListItem> Genders { get; set; }
        [Required, DisplayName("Material Statuses")]
        public List<SelectListItem> MaritalStatuses { get; set; }
    }
}
