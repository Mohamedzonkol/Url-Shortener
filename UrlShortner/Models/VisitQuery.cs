namespace UrlShortner.Models
{
    public class VisitQuery
    {
        public Guid LinkId { get; set; }
        public string Device { get; set; }
        public string IpAddress { get; set; }
    }
}
