using UrlShortner.Models;
using UrlShortner.Models.Entites;

namespace UrlShortner.Services
{
    public interface IUrlServices
    {
        Task<Link?> CreateShortLink(CreateShortLinkCommand command);
        Task RecordVisit(ShortLinkQuery query);
        Task<string> GetOriginalLink(ShortLinkQuery query);

    }
}
