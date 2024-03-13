namespace UrlShortner.Models.Entites
{
    public class Visit:Entity
    {
        public int Count { get; set; }
        public string? IpAddress { get; set; }
        public string? Device { get; set; }
        public Guid LinkId { get; set; }
        public Link Link { get; set; }
    }
}
