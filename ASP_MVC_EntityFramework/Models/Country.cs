using System.ComponentModel.DataAnnotations;

namespace ASP_MVC_EntityFramework.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }

        public List<City> Cities { get; set; } = new();
    }
}
