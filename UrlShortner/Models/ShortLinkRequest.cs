using Microsoft.AspNetCore.Mvc;

namespace UrlShortner.Models
{
    public class ShortLinkRequest
    {
        [FromQuery]
        public string ShortLink { get; set; }
    }
}
