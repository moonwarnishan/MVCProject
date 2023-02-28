using Microsoft.AspNetCore.Mvc;
using MVCProject.Factories;

namespace MVCProject.Controllers
{
    public class LanguageSelectController : Controller
    {
        private readonly ILanguageFactory _languageFactory;
        private readonly IPersoninfoLanguageFactory _personinfoFactory;
        private readonly IPersonFactory _personFactory;
        public LanguageSelectController(ILanguageFactory languageFactory, IPersoninfoLanguageFactory personinfoFactory, IPersonFactory personFactory)
        {
            _languageFactory = languageFactory;
            _personinfoFactory = personinfoFactory;
            _personFactory = personFactory;
        }
        public IActionResult Index()
        {
            return View(_languageFactory.PrepareLanguageModel());
        }
        [HttpPost]
        public IActionResult Redirect(Guid languageId)
        {
            var personInfo = _personinfoFactory.PersonBySpecificLanguage(languageId);
            foreach(var person in personInfo)
            {
                person.LanguageId = languageId;
                person.Language = _languageFactory.GetLanguageById(person.LanguageId);
                person.Person = _personFactory.GetPersonById(person.PersonId);
            }
            HttpContext.Session.Remove("languageId");
            HttpContext.Session.SetString("languageId",languageId.ToString());
            return View("~/Views/PersonsInfoLanguages/Index.cshtml", personInfo);
        }

    }
}
