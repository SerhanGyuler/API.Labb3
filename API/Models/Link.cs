using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;

        public int PersonId { get; set; }
        public int InterestId { get; set; }


        // Koppling till person och intresse
        public PersonInterest PersonInterest { get; set; }
    }


}



