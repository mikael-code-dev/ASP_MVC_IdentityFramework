using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ASP_MVC_EntityFramework.ViewModels
{
    public class CityViewModel
    {

        public int CountryId { get; set; }

        [Required(ErrorMessage = "Please, enter your City")]
        [Display(Name = "City")]
        public string Name { get; set; }
    }
}
