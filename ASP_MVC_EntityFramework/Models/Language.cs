using System.ComponentModel.DataAnnotations;

namespace ASP_MVC_EntityFramework.Models
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }
        public string? Name{ get; set; }

        public List<Person> People { get; set; } = new();
    }
}
