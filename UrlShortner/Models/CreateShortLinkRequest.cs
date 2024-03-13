using Microsoft.AspNetCore.Mvc;

namespace UrlShortner.Models
{
    public class CreateShortLinkRequest
    {

        [FromBody]
        public string OriginalLink { get; set; }
    }
}
