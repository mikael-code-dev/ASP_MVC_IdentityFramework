using ASP_MVC_EntityFramework.Models;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC_EntityFramework.ViewModels
{
    public class LanguageViewModel
    {
        public List<Language> Languages { get; set; } = new();

        [Required(ErrorMessage = "Must enter a Language")]
        [Display(Name = "Enter Language:")]
        public string? Name { get; set; }
    }
}
