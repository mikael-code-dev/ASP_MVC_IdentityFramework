using ASP_MVC_EntityFramework.Models;

namespace ASP_MVC_EntityFramework.ViewModels
{
    public class CountriesViewModel
    {
        public static List<City> Cities = new();

        public List<Country> Countries { get; set; } = new();
    }
}
