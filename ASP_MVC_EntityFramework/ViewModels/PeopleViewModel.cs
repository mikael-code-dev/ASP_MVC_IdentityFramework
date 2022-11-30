using ASP_MVC_EntityFramework.Models;

namespace ASP_MVC_EntityFramework.ViewModels
{
    public class PeopleViewModel : PersonViewModel
    {
        //public static List<Person> listOfPeople { get; set; } = new();

        public List<Person> listOfPeople { get; set; } = new();

        //public PersonViewModel PeopleCrudFunctions { get; set; } = new();
    }
}
