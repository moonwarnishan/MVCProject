using Microsoft.AspNetCore.Mvc.Rendering;
using MVCProject.Models;
using MVCProject.Domains;
using SimpleMVCProject.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MVCProject.Factories
{
    public class PersonFactory : IPersonFactory
    {
        private readonly ApplicationDbContext _dbContext;
        public PersonFactory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public PersonModel PreparePersonModel(Person person)
        {
            var personModel = new PersonModel();
            personModel.Key = person.Key;
            personModel.Name = person.Name;
            personModel.Gender = person.Gender;
            personModel.DateOfBirth = person.DateOfBirth;
            personModel.GenderInString = Enum.GetName(typeof(AllGenders), person.Gender);
            personModel.MaritalStatusInString = Enum.GetName(typeof(AllMaritalStatuses), person.MaritalStatus);
            Enum.GetValues(typeof(AllGenders)).Cast<AllGenders>()
                            .Select(g => new SelectListItem
                            {
                                Value = ((int)g).ToString(),
                                Text = g.ToString()
                            }).ToList().ForEach(x=>personModel.Genders.Add(x));

            Enum.GetValues(typeof(AllMaritalStatuses)).Cast<AllMaritalStatuses>()
                           .Select(g => new SelectListItem
                           {
                               Value = ((int)g).ToString(),
                               Text = g.ToString()
                           }).ToList().ForEach(x => personModel.MaritalStatuses.Add(x));

            return personModel;
        }

        public List<PersonModel> GetListOfPersonModelbyLanguage(Guid languageId)
        {
            var personModels = new List<PersonModel>();
            var persons = _dbContext.PersonInfoInDifferentLanguage.Where(x=>x.LanguageId == languageId).ToList();
            foreach (var person in persons)
            {
                var prsn = GetPersonById(person.PersonId);
                personModels.Add(PreparePersonModel(prsn));
            }
            return personModels;
        }

        public Person GetPersonById(Guid id)
        {
            var person =  _dbContext.Persons.Where(x => x.Key == id).FirstOrDefault();
            if(person==null)
            {
                return null;
            }
            return person;
        }

    }

}
