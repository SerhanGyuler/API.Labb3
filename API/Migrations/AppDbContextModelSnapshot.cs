﻿// <auto-generated />
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Models.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Att ta bilder med kamera",
                            Title = "Fotografi"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Att laga god mat",
                            Title = "Matlagning"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Att skriva kod i olika språk",
                            Title = "Programmering"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Upptäcka nya platser",
                            Title = "Resa"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Lyssna och skapa musik",
                            Title = "Musik"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Hålla kroppen i form",
                            Title = "Träning"
                        });
                });

            modelBuilder.Entity("API.Models.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InterestId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId", "InterestId");

                    b.ToTable("Links");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InterestId = 1,
                            PersonId = 1,
                            Url = "https://se.pinterest.com/"
                        },
                        new
                        {
                            Id = 2,
                            InterestId = 3,
                            PersonId = 1,
                            Url = "https://www.w3schools.com/"
                        },
                        new
                        {
                            Id = 3,
                            InterestId = 2,
                            PersonId = 2,
                            Url = "https://recept.se/"
                        },
                        new
                        {
                            Id = 4,
                            InterestId = 4,
                            PersonId = 3,
                            Url = "https://www.momondo.se/"
                        },
                        new
                        {
                            Id = 5,
                            InterestId = 5,
                            PersonId = 4,
                            Url = "https://spotify.com/"
                        },
                        new
                        {
                            Id = 6,
                            InterestId = 6,
                            PersonId = 2,
                            Url = "https://nordicwellness.se/"
                        },
                        new
                        {
                            Id = 7,
                            InterestId = 3,
                            PersonId = 3,
                            Url = "https://codecademy.com/"
                        },
                        new
                        {
                            Id = 8,
                            InterestId = 3,
                            PersonId = 1,
                            Url = "https://music.amazon.com/"
                        });
                });

            modelBuilder.Entity("API.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Alice Andersson",
                            PhoneNumber = "0701234567"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bob Berg",
                            PhoneNumber = "0727654321"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Carla Carlsson",
                            PhoneNumber = "0739876543"
                        },
                        new
                        {
                            Id = 4,
                            Name = "David Dahl",
                            PhoneNumber = "0761122334"
                        });
                });

            modelBuilder.Entity("API.Models.PersonInterest", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("InterestId")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "InterestId");

                    b.HasIndex("InterestId");

                    b.ToTable("PersonInterests");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            InterestId = 1
                        },
                        new
                        {
                            PersonId = 1,
                            InterestId = 3
                        },
                        new
                        {
                            PersonId = 2,
                            InterestId = 2
                        },
                        new
                        {
                            PersonId = 2,
                            InterestId = 6
                        },
                        new
                        {
                            PersonId = 3,
                            InterestId = 4
                        },
                        new
                        {
                            PersonId = 3,
                            InterestId = 3
                        },
                        new
                        {
                            PersonId = 4,
                            InterestId = 5
                        });
                });

            modelBuilder.Entity("API.Models.Link", b =>
                {
                    b.HasOne("API.Models.PersonInterest", "PersonInterest")
                        .WithMany("Links")
                        .HasForeignKey("PersonId", "InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonInterest");
                });

            modelBuilder.Entity("API.Models.PersonInterest", b =>
                {
                    b.HasOne("API.Models.Interest", "Interest")
                        .WithMany("PersonInterests")
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Person", "Person")
                        .WithMany("PersonInterests")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interest");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("API.Models.Interest", b =>
                {
                    b.Navigation("PersonInterests");
                });

            modelBuilder.Entity("API.Models.Person", b =>
                {
                    b.Navigation("PersonInterests");
                });

            modelBuilder.Entity("API.Models.PersonInterest", b =>
                {
                    b.Navigation("Links");
                });
#pragma warning restore 612, 618
        }
    }
}
