using ASP_MVC_EntityFramework.Data;
using ASP_MVC_EntityFramework.Models;
using ASP_MVC_EntityFramework.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_EntityFramework.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _context;
        CountryViewModel cvm = new();

        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var countries = _context.Countries.OrderBy(c => c.Name).ToList();
            return View(countries);
        }

        public IActionResult Create()
        {
            
            return View(cvm);
        }

        [HttpPost]
        public IActionResult Create(CountryViewModel country)
        {
            CountryViewModel cvm = new();

            ModelState.Remove("CountryId");
            if (ModelState.IsValid)
            {
                if (_context.Countries.FirstOrDefault(c => c.Name == country.Name) == null)
                {
                    Country countryToAdd = new Country() { Name = country.Name };
                    _context.Countries.Add(countryToAdd);
                    _context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(cvm);
            }
        }
    }
}
