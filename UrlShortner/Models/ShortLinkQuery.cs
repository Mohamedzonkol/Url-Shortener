
using Microsoft.AspNetCore.Mvc;

namespace UrlShortner.Models
{
    public class ShortLinkQuery
    {
        public string ShortLink { get; set; }
        public string Device { get; set; }
        public string IpAddress { get; set; }
    }
}
