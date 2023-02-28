using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class PersonModel
    {
        public PersonModel()
        {
            MaritalStatuses = new List<SelectListItem>();
            Genders = new List<SelectListItem>();
        }
        public Guid Key { get; set; }
        [Required, DisplayName("Name")]
        public string Name { get; set; }
        [Required, DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int Gender { get; set; }
        [Required,DisplayName("Gender")]
        public string GenderInString { get; set; }
        [Required, DisplayName("Marital Status")]
        public int MaritalStatus { get; set; }
        [Required, DisplayName("Marital Status")]
        public string MaritalStatusInString { get; set; }
        [Required, DisplayName("Language")]
        public Guid LanguageId { get; set; }
        [Required, DisplayName("Creation Date")]
        public DateTime CreationDate { get; set; }
        public IList<SelectListItem> MaritalStatuses { get; set;}
        public IList<SelectListItem> Genders { get; set; }
        

    }
}
