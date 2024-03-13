using Microsoft.AspNetCore.Mvc;

namespace UrlShortner.Models
{
    public class CreateShortLinkCommand
    {
        public string OriginalLink { get; set; }

    }
}
