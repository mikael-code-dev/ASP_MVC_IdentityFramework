﻿// <auto-generated />
using ASP_MVC_EntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASP_MVC_EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ASP_MVC_EntityFramework.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            CountryId = 1,
                            Name = "Paris"
                        },
                        new
                        {
                            CityId = 2,
                            CountryId = 1,
                            Name = "Nantes"
                        },
                        new
                        {
                            CityId = 3,
                            CountryId = 2,
                            Name = "Ljusdal"
                        },
                        new
                        {
                            CityId = 4,
                            CountryId = 2,
                            Name = "Boden"
                        },
                        new
                        {
                            CityId = 5,
                            CountryId = 3,
                            Name = "Skagen"
                        },
                        new
                        {
                            CityId = 6,
                            CountryId = 3,
                            Name = "Odense"
                        });
                });

            modelBuilder.Entity("ASP_MVC_EntityFramework.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            Name = "France"
                        },
                        new
                        {
                            CountryId = 2,
                            Name = "Sweden"
                        },
                        new
                        {
                            CountryId = 3,
                            Name = "Denmark"
                        });
                });

            modelBuilder.Entity("ASP_MVC_EntityFramework.Models.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LanguageId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageId");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            LanguageId = 1,
                            Name = "Swedish"
                        },
                        new
                        {
                            LanguageId = 2,
                            Name = "English"
                        },
                        new
                        {
                            LanguageId = 3,
                            Name = "Danish"
                        },
                        new
                        {
                            LanguageId = 4,
                            Name = "French"
                        });
                });

            modelBuilder.Entity("ASP_MVC_EntityFramework.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            LanguageId = 0,
                            Name = "Kalle Person",
                            PhoneNumber = "555-5555"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 2,
                            LanguageId = 0,
                            Name = "Jennie Antonsson",
                            PhoneNumber = "444-4444"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 3,
                            LanguageId = 0,
                            Name = "Wendely Blom",
                            PhoneNumber = "222-2222"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 4,
                            LanguageId = 0,
                            Name = "Belly Button",
                            PhoneNumber = "000-4444"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 5,
                            LanguageId = 0,
                            Name = "Alma Starstruck",
                            PhoneNumber = "888-4444"
                        },
                        new
                        {
                            Id = 6,
                            CityId = 6,
                            LanguageId = 0,
                            Name = "Hugo Magnusson",
                            PhoneNumber = "999-9999"
                        });
                });

            modelBuilder.Entity("LanguagePerson", b =>
                {
                    b.Property<int>("LanguagesLanguageId")
                        .HasColumnType("int");

                    b.Property<int>("PeopleId")
                        .HasColumnType("int");

                    b.HasKey("LanguagesLanguageId", "PeopleId");

                    b.HasIndex("PeopleId");

                    b.ToTable("LanguagePerson");

                    b.HasData(
                        new
                        {
                            LanguagesLanguageId = 1,
                            PeopleId = 1
                        },
                        new
                        {
                            LanguagesLanguageId = 2,
                            PeopleId = 1
                        },
                        new
                        {
                            LanguagesLanguageId = 3,
                            PeopleId = 2
                        },
                        new
                        {
                            LanguagesLanguageId = 2,
                            PeopleId = 2
                        },
                        new
                        {
                            LanguagesLanguageId = 3,
                            PeopleId = 3
                        },
                        new
                        {
                            LanguagesLanguageId = 4,
                            PeopleId = 4
                        },
                        new
                        {
                            LanguagesLanguageId = 1,
                            PeopleId = 5
                        },
                        new
                        {
                            LanguagesLanguageId = 2,
                            PeopleId = 6
                        });
                });

            modelBuilder.Entity("ASP_MVC_EntityFramework.Models.City", b =>
                {
                    b.HasOne("ASP_MVC_EntityFramework.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("ASP_MVC_EntityFramework.Models.Person", b =>
                {
                    b.HasOne("ASP_MVC_EntityFramework.Models.City", "City")
                        .WithMany("Persons")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("LanguagePerson", b =>
                {
                    b.HasOne("ASP_MVC_EntityFramework.Models.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguagesLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASP_MVC_EntityFramework.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ASP_MVC_EntityFramework.Models.City", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("ASP_MVC_EntityFramework.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
