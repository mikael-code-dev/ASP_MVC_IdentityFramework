using ASP_MVC_EntityFramework.Models;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC_EntityFramework.ViewModels
{
    public class PersonViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name:")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        [Display(Name = "Phone Number:")]
        public string PhoneNumber { get; set; } = string.Empty;

        //public Country? Country { get; set; }

        //[Required(ErrorMessage = "Country is required")]
        //[Display(Name = "Country:")]
        //public int CountryId { get; set; }

        public City? City { get; set; }

        [Display(Name = "City:")]
        [Required(ErrorMessage = "City is Required")] // Don't work!
        public int CityId { get; set; }

        //public Language? Language { get; set; }

        [Display(Name = "Language:")]
        [Required(ErrorMessage = "Language is Required")]
        public int LanguageId { get; set; }
    }
}
