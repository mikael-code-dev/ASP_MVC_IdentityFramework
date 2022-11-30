using ASP_MVC_EntityFramework.Data;
using ASP_MVC_EntityFramework.Models;
using ASP_MVC_EntityFramework.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC_EntityFramework.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ApplicationDbContext _context;
        LanguageViewModel lvm = new();

        public LanguageController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var languages = _context.Languages.OrderBy(l => l.Name).ToList();

            return View(languages);
        }

        public IActionResult Create()
        {
            return View(lvm);
        }

        [HttpPost]
        public IActionResult Create(LanguageViewModel language)
        {
            if (ModelState.IsValid)
            {
                Language lang = new();
                lang.Name = language.Name;
                _context.Languages.Add(lang);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(language);
            }

        }
    }
}
