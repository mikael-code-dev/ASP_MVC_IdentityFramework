using ASP_MVC_EntityFramework.Data;
using ASP_MVC_EntityFramework.Models;
using ASP_MVC_EntityFramework.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP_MVC_EntityFramework.Controllers
{
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cities = _context.Cities.OrderBy(c => c.Name).ToList();

            return View(cities);
        }

        public IActionResult Create()
        {
            var countries = _context.Countries;
            ViewBag.CountriesList = new SelectList(countries, "CountryId", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(CityViewModel city)
        {
            if (ModelState.IsValid && city.CountryId != 0)
            {
                City cityToAdd = new() { Name = city.Name, CountryId = city.CountryId };
                _context.Cities.Add(cityToAdd);
                _context.SaveChanges();
            }

            return View();
        }
    }
}
