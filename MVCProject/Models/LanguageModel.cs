using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace MVCProject.Models
{
    public class LanguageModel
    {
        public LanguageModel()
        {
            AllLanguages = new List<SelectListItem>();
        }
        [DisplayName("Language Name")]
        public string? LanguageName { get; set; }
        [DisplayName("Languages")]
        public string LanguageId { get; set; }
        [DisplayName("All Language")]
        public List<SelectListItem> AllLanguages { get; set; }
    }
}
