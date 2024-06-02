using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos
{
    public class SubscriberDto
    {
        public String Email { get; set; } 
        public bool dailynewsletter { get; set; }
        public bool advertisingupdates { get; set; }
        public bool weekinreview { get; set; }
        public bool eventupdates { get; set; }
        public bool startupweekly { get; set; }
        public bool podcasts { get; set; }
    }
}
