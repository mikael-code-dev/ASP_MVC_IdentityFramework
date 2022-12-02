using ASP_MVC_EntityFramework.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_EntityFramework.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 1, Name = "Swedish" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 2, Name = "English" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 3, Name = "Danish" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 4, Name = "French" });

            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 1, Name = "France" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 2, Name = "Sweden" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 3, Name = "Denmark" });

            modelBuilder.Entity<City>().HasData(new City { CityId = 1, Name = "Paris", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 2, Name = "Nantes", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 3, Name = "Ljusdal", CountryId = 2 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 4, Name = "Boden", CountryId = 2 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 5, Name = "Skagen", CountryId = 3 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 6, Name = "Odense", CountryId = 3 });

            modelBuilder.Entity<Person>().HasData(new Person { Id = 1, Name = "Kalle Person", PhoneNumber = "555-5555", CityId = 1 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 2, Name = "Jennie Antonsson", PhoneNumber = "444-4444", CityId = 2 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 3, Name = "Wendely Blom", PhoneNumber = "222-2222", CityId = 3 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 4, Name = "Belly Button", PhoneNumber = "000-4444", CityId = 4 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 5, Name = "Alma Starstruck", PhoneNumber = "888-4444", CityId = 5 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 6, Name = "Hugo Magnusson", PhoneNumber = "999-9999", CityId = 6 });


            modelBuilder.Entity<Person>()
                .HasMany(x => x.Languages)
                .WithMany(x => x.People)
                .UsingEntity(j => j.HasData(
                                        //new { PeoplePersonId = 1, LanguagesLanguageId = 1 },
                                        //new { PeoplePersonId = 1, LanguagesLanguageId = 2 },
                                        //new { PeoplePersonId = 2, LanguagesLanguageId = 3 },
                                        //new { PeoplePersonId = 2, LanguagesLanguageId = 2 },
                                        //new { PeoplePersonId = 3, LanguagesLanguageId = 3 },
                                        //new { PeoplePersonId = 4, LanguagesLanguageId = 4 },
                                        //new { PeoplePersonId = 5, LanguagesLanguageId = 1 },
                                        //new { PeoplePersonId = 6, LanguagesLanguageId = 2 }

                    new { PeopleId = 1, LanguagesLanguageId = 1 },
                    new { PeopleId = 1, LanguagesLanguageId = 2 },
                    new { PeopleId = 2, LanguagesLanguageId = 3 },
                    new { PeopleId = 2, LanguagesLanguageId = 2 },
                    new { PeopleId = 3, LanguagesLanguageId = 3 },
                    new { PeopleId = 4, LanguagesLanguageId = 4 },
                    new { PeopleId = 5, LanguagesLanguageId = 1 },
                    new { PeopleId = 6, LanguagesLanguageId = 2 }
                    ));

            // Roles
            string adminRoleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = userRoleId,
                    Name = "User",
                    NormalizedName = "USER"
                });

            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                FirstName = "Admin",
                LastName = "Adminsson",
                Birthday = "2000-01-01",
                PasswordHash = hasher.HashPassword(null, "password")
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = userId,
            });
        }
    }
}
