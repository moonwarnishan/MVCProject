using Microsoft.AspNetCore.Mvc.Rendering;
using MVCProject.Domains;
using MVCProject.Models;
using SimpleMVCProject.Data;

namespace MVCProject.Factories
{
    public class PersoninfoLanguageFactory : IPersoninfoLanguageFactory
    {
        private readonly ApplicationDbContext _dbContext;
        public PersoninfoLanguageFactory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public PersonLanguageModel PreparePersonLanguage()
        {
            var personLanguage = new PersonLanguageModel();
            Enum.GetValues(typeof(AllGenders)).Cast<AllGenders>()
                            .Select(g => new SelectListItem
                            {
                                Value = ((int)g).ToString(),
                                Text = g.ToString()
                            }).ToList().ForEach(x => personLanguage.Genders.Add(x));

            Enum.GetValues(typeof(AllMaritalStatuses)).Cast<AllMaritalStatuses>()
                           .Select(g => new SelectListItem
                           {
                               Value = ((int)g).ToString(),
                               Text = g.ToString()
                           }).ToList().ForEach(x => personLanguage.MaritalStatuses.Add(x));
            /*var languages = _dbContext.Languages.ToList();
            foreach(var language in languages)
            {
                personLanguage.Languages.Add(new SelectListItem { Value=language.Id.ToString(),Text = language.Name });
            }*/
            var persons = _dbContext.Persons.ToList();
            foreach (var person in persons)
            {
                personLanguage.Persons.Add(new SelectListItem { Value = person.Key.ToString(), Text = person.Name });
            }

            return personLanguage;

        }

        public List<PersonsInfoLanguagesModel> PersonBySpecificLanguage(Guid languageId)
        {
            var persons = _dbContext.PersonInfoInDifferentLanguage.Where(x => x.LanguageId == languageId).ToList();
            var model = new List<PersonsInfoLanguagesModel>();
            foreach (var person in persons)
            {
                model.Add(new PersonsInfoLanguagesModel()
                {
                    Id = person.Id,
                    LanguageId = person.LanguageId,
                    Name = person.Name,
                    DateOfBirth = person.DateOfBirth,
                    MaritalStatus = person.MaritalStatus,
                    Gender = person.Gender,
                    PersonId = person.PersonId,
                    MaritalStatusInString = Enum.GetName(typeof(AllMaritalStatuses), person.MaritalStatus),
                    GenderInString = Enum.GetName(typeof(AllGenders), person.Gender)
                });
            }
            return model;
        }
        public PersonLanguageModel PreparePersonForEdit(Guid personId)
        {
            var model = new PersonLanguageModel();
            var person = _dbContext.PersonInfoInDifferentLanguage.Where(x => x.Id == personId).FirstOrDefault();
            if (person == null)
            {
                return model;
            }
            model.DateOfBirth = person.DateOfBirth;
            model.Name = person.Name;
            model.Id = person.Id;
            model.Gender = person.Gender;
            model.LanguageId = person.LanguageId;
            model.MaritalStatus = person.MaritalStatus;
            model.PersonId = person.PersonId;
            model.LanguageId = person.LanguageId;
            Enum.GetValues(typeof(AllGenders)).Cast<AllGenders>()
                            .Select(g => new SelectListItem
                            {
                                Value = ((int)g).ToString(),
                                Text = g.ToString()
                            }).ToList().ForEach(x => model.Genders.Add(x));

            Enum.GetValues(typeof(AllMaritalStatuses)).Cast<AllMaritalStatuses>()
                           .Select(g => new SelectListItem
                           {
                               Value = ((int)g).ToString(),
                               Text = g.ToString()
                           }).ToList().ForEach(x => model.MaritalStatuses.Add(x));

            return model;
        }

    }
}
