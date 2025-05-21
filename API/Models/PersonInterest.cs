namespace API.Models
{
    public class PersonInterest
    {
        public int PersonId { get; set; }
        public Person? Person { get; set; }

        public int InterestId { get; set; }
        public Interest? Interest { get; set; }

        public List<Link> Links { get; set; } = new(); // REMOVE LATER
    }
}
