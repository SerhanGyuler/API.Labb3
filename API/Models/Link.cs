using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;

        public ICollection<Person> Persons { get; set; } = new List<Person>();
        public ICollection<Interest> Interests { get; set; } = new List<Interest>();
    }

}



