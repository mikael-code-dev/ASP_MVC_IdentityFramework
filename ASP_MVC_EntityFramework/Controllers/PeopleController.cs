using ASP_MVC_EntityFramework.Data;
using ASP_MVC_EntityFramework.Models;
using ASP_MVC_EntityFramework.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ASP_MVC_EntityFramework.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;
        static PeopleViewModel pvm = new();

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            pvm.listOfPeople = _context.People
                .Include(x => x.City)
                .Include(y => y.City.Country)
                .Include(z => z.Languages).ToList();

            //var people = _context.People;
            //ViewBag.CountriesList = new SelectList(people, "Name", "Id");

            return View(pvm);
        }

        public IActionResult Create()
        {
            var pvm = new PersonViewModel();
            var languages = _context.Languages;
            var cities = _context.Cities;

            ViewBag.CitiesList = new SelectList(cities, "CityId", "Name");
            ViewBag.LanguagesList = new SelectList(languages, "LanguageId", "Name");

            return View(pvm);
        }

        [HttpPost]
        public IActionResult Create(PersonViewModel person)
        {
            PersonViewModel pwm = new PersonViewModel();
            ModelState.Remove("Id");
            if (ModelState.IsValid && person.CityId != 0 && person.LanguageId != 0)
            {
                var personToAdd = new Person()
                { Name = person.Name, PhoneNumber = person.PhoneNumber, CityId = person.CityId };

                Language? lang = _context.Languages.Find(person.LanguageId);
                if (lang != null)
                {
                    personToAdd.Languages.Add(lang);
                }

                _context.People.Add(personToAdd);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                if (person.CityId == 0)
                {
                    ViewBag.ErrorCity = "City is Required";
                }

                if (person.LanguageId == 0)
                {
                    ViewBag.ErrorLanguage = "Language is Required";
                }

                var languages = _context.Languages;
                var cities = _context.Cities;
                ViewBag.CitiesList = new SelectList(cities, "CityId", "Name");
                ViewBag.LanguagesList = new SelectList(languages, "LanguageId", "Name");
                return View(pwm);
            }
        }

        public IActionResult EditPerson(string id)
        {
            var pvm = new PersonViewModel();


            int numId = int.Parse(id);
            Person person = _context.People.Find(numId);

            pvm.Name = person.Name;
            pvm.PhoneNumber = person.PhoneNumber;
            pvm.CityId = person.CityId;
            pvm.LanguageId = person.LanguageId;

            var languages = _context.Languages;
            var cities = _context.Cities;
            ViewBag.CitiesList = new SelectList(cities, "CityId", "Name");
            ViewBag.LanguagesList = new SelectList(languages, "LanguageId", "Name");

            return View(pvm);
        }

        [HttpPost]
        public IActionResult EditPerson(PersonViewModel person)
        {
            int numId = person.Id;
            Person personToEdit = _context.People.Find(numId);

            if (ModelState.IsValid)
            {
                personToEdit.Name = person.Name;
                personToEdit.PhoneNumber = person.PhoneNumber;
                personToEdit.CityId = person.CityId;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(person);
            }
        }

        public IActionResult Details(int id)
        {
            Person? person = _context.People
                .Include(p => p.City)
                .Include(p => p.City.Country)
                .Include(p => p.Languages)
                .FirstOrDefault(p => p.Id == id);
                                            
            if (person != null)
            {
                return View(person);
            }

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            int? numId = int.Parse(id);
            Person person = _context.People.Find(numId);
            if (person != null)
            {
                _context.People.Remove(person);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddLanguage(int id, string lang)
        {
            var language = _context.Languages.FirstOrDefault(l => l.Name == lang);


            var personToChange = _context.People.Find(id);
            if (personToChange != null)
            {
                if(language != null)
                {
                    personToChange.Languages.Add(language);
                    _context.SaveChanges();
                }
                else
                {
                    // Add new Language in DB
                    Language newLang = new Language() { Name = lang};
                    _context.Languages.Add(newLang);
                    personToChange.Languages.Add(newLang);
                    _context.SaveChanges();
                }
            }

            //return View();
            return RedirectToAction("Index");
        }
    }
}
