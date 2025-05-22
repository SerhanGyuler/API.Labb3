using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<PersonInterest> PersonInterests { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Nyckel för PersonInterest
            modelBuilder.Entity<PersonInterest>()
                .HasKey(pi => new { pi.PersonId, pi.InterestId });

            // Relationer för PersonInterest
            modelBuilder.Entity<PersonInterest>()
                .HasOne(pi => pi.Person)
                .WithMany(p => p.PersonInterests)
                .HasForeignKey(pi => pi.PersonId);

            modelBuilder.Entity<PersonInterest>()
                .HasOne(pi => pi.Interest)
                .WithMany(i => i.PersonInterests)
                .HasForeignKey(pi => pi.InterestId);

            // Link hör till en specifik PersonInterest
            modelBuilder.Entity<Link>()
                .HasOne(l => l.PersonInterest)
                .WithMany(pi => pi.Links)
                .HasForeignKey(l => new { l.PersonId, l.InterestId });

            // Seed: Persons
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "Alice Andersson", PhoneNumber = "0701234567" },
                new Person { Id = 2, Name = "Bob Berg", PhoneNumber = "0727654321" },
                new Person { Id = 3, Name = "Carla Carlsson", PhoneNumber = "0739876543" },
                new Person { Id = 4, Name = "David Dahl", PhoneNumber = "0761122334" }
            );

            // Seed: Interests
            modelBuilder.Entity<Interest>().HasData(
                new Interest { Id = 1, Title = "Fotografi", Description = "Att ta bilder med kamera" },
                new Interest { Id = 2, Title = "Matlagning", Description = "Att laga god mat" },
                new Interest { Id = 3, Title = "Programmering", Description = "Att skriva kod i olika språk" },
                new Interest { Id = 4, Title = "Resa", Description = "Upptäcka nya platser" },
                new Interest { Id = 5, Title = "Musik", Description = "Lyssna och skapa musik" },
                new Interest { Id = 6, Title = "Träning", Description = "Hålla kroppen i form" }
            );

            // Seed: PersonInterest
            modelBuilder.Entity<PersonInterest>().HasData(
                new { PersonId = 1, InterestId = 1 },
                new { PersonId = 1, InterestId = 3 },
                new { PersonId = 2, InterestId = 2 },
                new { PersonId = 2, InterestId = 6 },
                new { PersonId = 3, InterestId = 4 },
                new { PersonId = 3, InterestId = 3 },
                new { PersonId = 4, InterestId = 5 }
            );

            // Seed: Links (nu med PersonId + InterestId)
            modelBuilder.Entity<Link>().HasData(
                new Link { Id = 1, Url = "https://se.pinterest.com/", PersonId = 1, InterestId = 1 },
                new Link { Id = 2, Url = "https://www.w3schools.com/", PersonId = 1, InterestId = 3 },
                new Link { Id = 3, Url = "https://recept.se/", PersonId = 2, InterestId = 2 },
                new Link { Id = 4, Url = "https://www.momondo.se/", PersonId = 3, InterestId = 4 },
                new Link { Id = 5, Url = "https://spotify.com/", PersonId = 4, InterestId = 5 },
                new Link { Id = 6, Url = "https://nordicwellness.se/", PersonId = 2, InterestId = 6 },
                new Link { Id = 7, Url = "https://codecademy.com/", PersonId = 3, InterestId = 3 },
                new Link { Id = 8, Url = "https://music.amazon.com/", PersonId = 1, InterestId = 3 }
            );
        }
    }
}
