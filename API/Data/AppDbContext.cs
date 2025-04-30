using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Persons
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "Alice Andersson", PhoneNumber = "0701234567" },
                new Person { Id = 2, Name = "Bob Berg", PhoneNumber = "0727654321" },
                new Person { Id = 3, Name = "Carla Carlsson", PhoneNumber = "0739876543" },
                new Person { Id = 4, Name = "David Dahl", PhoneNumber = "0761122334" }
            );

            // Seed Interests
            modelBuilder.Entity<Interest>().HasData(
                new Interest { Id = 1, Title = "Fotografi", Description = "Att ta bilder med kamera" },
                new Interest { Id = 2, Title = "Matlagning", Description = "Att laga god mat" },
                new Interest { Id = 3, Title = "Programmering", Description = "Att skriva kod i olika språk" },
                new Interest { Id = 4, Title = "Resa", Description = "Upptäcka nya platser" },
                new Interest { Id = 5, Title = "Musik", Description = "Lyssna och skapa musik" },
                new Interest { Id = 6, Title = "Träning", Description = "Hålla kroppen i form" }
            );

            // Seed Links (OBS! utan PersonId och InterestId nu)
            modelBuilder.Entity<Link>().HasData(
                new Link { Id = 1, Url = "https://se.pinterest.com/" },
                new Link { Id = 2, Url = "https://www.w3schools.com/" },
                new Link { Id = 3, Url = "https://recept.se/" },
                new Link { Id = 4, Url = "https://www.momondo.se/" },
                new Link { Id = 5, Url = "https://spotify.com/" },
                new Link { Id = 6, Url = "https://nordicwellness.se/" },
                new Link { Id = 7, Url = "https://codecademy.com/" },
                new Link { Id = 8, Url = "https://music.amazon.com/" }
            );

            // Seed relationer mellan Link och Person
            modelBuilder.Entity<Link>()
                .HasMany(l => l.Persons)
                .WithMany(p => p.Links)
                .UsingEntity(j => j.HasData(
                    new { LinksId = 1, PersonsId = 1 },
                    new { LinksId = 2, PersonsId = 1 },
                    new { LinksId = 3, PersonsId = 2 },
                    new { LinksId = 4, PersonsId = 3 },
                    new { LinksId = 5, PersonsId = 4 },
                    new { LinksId = 6, PersonsId = 2 },
                    new { LinksId = 7, PersonsId = 3 },
                    new { LinksId = 8, PersonsId = 1 }
                ));

            // Seed relationer mellan Link och Interest
            modelBuilder.Entity<Link>()
                .HasMany(l => l.Interests)
                .WithMany(i => i.Links)
                .UsingEntity(j => j.HasData(
                    new { LinksId = 1, InterestsId = 1 },
                    new { LinksId = 2, InterestsId = 3 },
                    new { LinksId = 3, InterestsId = 2 },
                    new { LinksId = 4, InterestsId = 4 },
                    new { LinksId = 5, InterestsId = 5 },
                    new { LinksId = 6, InterestsId = 6 },
                    new { LinksId = 7, InterestsId = 3 },
                    new { LinksId = 8, InterestsId = 5 }
                ));
        }
    }
}
