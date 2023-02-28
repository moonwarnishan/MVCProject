using MVCProject.Domains;
using MVCProject.Models;

namespace MVCProject.Factories
{
    public interface ILanguageFactory
    {
        LanguageModel PrepareLanguageModel();
        Language GetLanguageById(Guid id);
    }
}
