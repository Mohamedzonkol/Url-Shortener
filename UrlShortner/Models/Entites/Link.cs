namespace UrlShortner.Models.Entites
{
    public class Link:Entity
    {
        public string OriginalLink { get; set; }
        public string ShortnerLink { get; set; }
        public string Hash { get; set; }

    }
}
