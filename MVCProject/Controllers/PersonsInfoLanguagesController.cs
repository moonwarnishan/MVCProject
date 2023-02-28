using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCProject.Domains;
using MVCProject.Factories;
using MVCProject.Models;
using SimpleMVCProject.Data;

namespace MVCProject.Controllers
{
    public class PersonsInfoLanguagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPersoninfoLanguageFactory _personinfoLanguageFactory;
        private readonly IPersonFactory _personFactory;
        private readonly ILanguageFactory _languageFactory;

        public PersonsInfoLanguagesController(ApplicationDbContext context, IPersoninfoLanguageFactory personinfoLanguageFactor, IPersonFactory personFactory, ILanguageFactory languageFactory)
        {
            _context = context;
            _personinfoLanguageFactory = personinfoLanguageFactor;
            _personFactory = personFactory;
            _languageFactory = languageFactory;
        }

        // GET: PersonsInfoLanguages
        public async Task<IActionResult> Index()
        {
            var languageId = Guid.Parse(HttpContext.Session.GetString("languageId"));
            var personInfo = _personinfoLanguageFactory.PersonBySpecificLanguage(languageId);
            foreach (var person in personInfo)
            {
                person.LanguageId = languageId;
                person.Language = _languageFactory.GetLanguageById(person.LanguageId);
                person.Person = _personFactory.GetPersonById(person.PersonId);
            }
            return View(personInfo);
        }

        // GET: PersonsInfoLanguages/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.PersonInfoInDifferentLanguage == null)
            {
                return NotFound();
            }

            var personsInfoLanguages = await _context.PersonInfoInDifferentLanguage
                .Include(p => p.Language)
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personsInfoLanguages == null)
            {
                return NotFound();
            }

            return View(personsInfoLanguages);
        }

        // GET: PersonsInfoLanguages/Create
        public IActionResult Create()
        {
            return View(_personinfoLanguageFactory.PreparePersonLanguage());
        }

        // POST: PersonsInfoLanguages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DateOfBirth,Gender,MaritalStatus,PersonId,LanguageId")] PersonsInfoLanguages personsInfoLanguages)
        {
            var personLang = new PersonsInfoLanguages();
            var person = _personFactory.GetPersonById(personsInfoLanguages.PersonId);
            personLang.MaritalStatus = person.MaritalStatus;
            personLang.Name = personsInfoLanguages.Name;
            personLang.Gender = person.Gender;
            personLang.DateOfBirth = person.DateOfBirth;
            personLang.LanguageId = Guid.Parse(HttpContext.Session.GetString("languageId"));
            personLang.PersonId = personsInfoLanguages.PersonId;
            if(_context.PersonInfoInDifferentLanguage.Where(x=>x.LanguageId == personLang.LanguageId && x.PersonId == personsInfoLanguages.PersonId).Count()>0)
            {
                return RedirectToAction(nameof(AlreadyExist));
            }
            personLang.Id = Guid.NewGuid();
            _context.PersonInfoInDifferentLanguage.Add(personLang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: PersonsInfoLanguages/Edit/5
        public async Task<IActionResult> Edit(Guid id,Guid languageId)
        {
            if (id == null || _context.PersonInfoInDifferentLanguage == null)
            {
                return NotFound();
            }
            var personInfoLanguages= _context.PersonInfoInDifferentLanguage.Where(x=>x.Id== id).FirstOrDefault();
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name", personInfoLanguages.LanguageId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Key", "Name", personInfoLanguages.PersonId);
            var model = _personinfoLanguageFactory.PreparePersonForEdit(id);

            return View(model);
        }

        // POST: PersonsInfoLanguages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,Guid languageId, [Bind("Id,Name,DateOfBirth,Gender,MaritalStatus,PersonId,LanguageId")] PersonLanguageModel personsInfoLanguages)
        {
            if (id != personsInfoLanguages.Id)
            {
                return NotFound();
            }
            var model = _context.PersonInfoInDifferentLanguage.Where(x=>x.Id== id).First();
            model.Name = personsInfoLanguages.Name;
            model.Gender = personsInfoLanguages.Gender;
            model.MaritalStatus = personsInfoLanguages.MaritalStatus;
            model.DateOfBirth = personsInfoLanguages.DateOfBirth;
            _context.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Delete(Guid id)
        {
           return await DeleteConfirmed(id);
        }

        // POST: PersonsInfoLanguages/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.PersonInfoInDifferentLanguage == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PersonInfoInDifferentLanguage'  is null.");
            }
            var personsInfoLanguages = await _context.PersonInfoInDifferentLanguage.FindAsync(id);
            if (personsInfoLanguages != null)
            {
                _context.PersonInfoInDifferentLanguage.Remove(personsInfoLanguages);
            }
            await _context.SaveChangesAsync();
            var languageId = Guid.Parse(HttpContext.Session.GetString("languageId"));
            var personInfo = _personinfoLanguageFactory.PersonBySpecificLanguage(languageId);
            foreach (var person in personInfo)
            {
                person.LanguageId = languageId;
                person.Language = _languageFactory.GetLanguageById(person.LanguageId);
                person.Person = _personFactory.GetPersonById(person.PersonId);
            }

            return View("~/Views/PersonsInfoLanguages/Index.cshtml", personInfo);
        }
        public async Task<IActionResult> AlreadyExist()
        {
            return View();
        }
        private bool PersonsInfoLanguagesExists(Guid id)
        {
          return (_context.PersonInfoInDifferentLanguage?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
