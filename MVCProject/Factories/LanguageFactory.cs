using Microsoft.AspNetCore.Mvc.Rendering;
using MVCProject.Domains;
using MVCProject.Models;
using SimpleMVCProject.Data;

namespace MVCProject.Factories
{
    public class LanguageFactory : ILanguageFactory
    {
        private readonly ApplicationDbContext _dbContext;
        public LanguageFactory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Language GetLanguageById(Guid id)
        {
            return _dbContext.Languages.Where(x => x.Id == id).FirstOrDefault();
        }

        public LanguageModel PrepareLanguageModel()
        {
            var model = new LanguageModel();
            var languages = _dbContext.Languages.ToList();
            foreach(var language in languages)
            {
                var SelectListItem = new SelectListItem() { Value = language.Id.ToString(), Text = language.Name };
                model.AllLanguages.Add(SelectListItem);
            }

            return model;
        }
    }
}
