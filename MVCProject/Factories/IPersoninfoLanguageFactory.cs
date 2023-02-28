using MVCProject.Domains;
using MVCProject.Models;

namespace MVCProject.Factories
{
    public interface IPersoninfoLanguageFactory
    {
        PersonLanguageModel PreparePersonLanguage();
        List<PersonsInfoLanguagesModel> PersonBySpecificLanguage(Guid languageId);
        PersonLanguageModel PreparePersonForEdit(Guid personId);
    }
}
