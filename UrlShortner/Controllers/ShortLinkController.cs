using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UrlShortner.Dbcontexts;
using UrlShortner.Models;
using UrlShortner.Models.Entites;
using UrlShortner.Reposerties;
using UrlShortner.Services;

namespace UrlShortner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShortLinkController(IUrlServices _urlServices) : Controller
    {
        [HttpPost("CreateShortLink")]
        public async Task<IActionResult> CreateShortLink(CreateShortLinkRequest request)
        {
            var command = new CreateShortLinkCommand
            {
                OriginalLink = request.OriginalLink
            };
            var shortLink = await _urlServices.CreateShortLink(command);
            return Ok(shortLink);
        }
        [HttpGet("QueryShortLink")]
        public async Task<IActionResult> QueryShortLink(ShortLinkRequest request)
        {
            var IpAddress = GetClientIpAddress(HttpContext);
            var userAgent = HttpContext.Request.Headers["User-Agent"];
            var query =new ShortLinkQuery
            {
                Device = userAgent,
                IpAddress = IpAddress,
                ShortLink = request.ShortLink
            };
           await _urlServices.RecordVisit(query);
            var originalLink=await _urlServices.GetOriginalLink(query);
            return Redirect(originalLink);
        }

        private string GetClientIpAddress(HttpContext context)
        {
            string clientIp = context.Request.Headers["X-Real-Ip"].ToString();
            if (string.IsNullOrEmpty(clientIp))
            {
                clientIp = context.Connection.RemoteIpAddress.ToString();
            }
            return clientIp;
        }
    }
}
