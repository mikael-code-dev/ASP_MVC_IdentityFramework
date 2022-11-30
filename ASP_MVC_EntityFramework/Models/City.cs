using System.ComponentModel.DataAnnotations;

namespace ASP_MVC_EntityFramework.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string? Name { get; set; }

        public List<Person> Persons { get; set; } = new();

        public int CountryId { get; set; }

        public Country? Country { get; set; }
    }
}
