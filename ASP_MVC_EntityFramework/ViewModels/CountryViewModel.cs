using System.ComponentModel.DataAnnotations;

namespace ASP_MVC_EntityFramework.ViewModels
{
    public class CountryViewModel
    {
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Please, enter your Country")]
        [Display(Name = "Country")]
        public string Name { get; set; }
    }
}
