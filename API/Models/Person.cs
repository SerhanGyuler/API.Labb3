using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public List<PersonInterest> PersonInterests { get; set; } = new();
    }
}
