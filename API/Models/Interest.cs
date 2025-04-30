namespace API.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<Link> Links { get; set; } = new();
    }
}
