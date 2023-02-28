using MVCProject.Domains;
using MVCProject.Models;

namespace MVCProject.Factories
{
    public interface IPersonFactory
    {
        PersonModel PreparePersonModel(Person person);
        List<PersonModel> GetListOfPersonModelbyLanguage(Guid languageId);
        Person GetPersonById(Guid id);
    }
}
