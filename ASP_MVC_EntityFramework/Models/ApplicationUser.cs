using Microsoft.AspNetCore.Identity;

namespace ASP_MVC_EntityFramework.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string?  LastName { get; set; }
        public string? Birthday { get; set; }
        public bool Admin { get; set; }
    }
}
