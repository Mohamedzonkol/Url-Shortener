using Azure.Core;
using System.Net;
using UrlShortner.Models;
using UrlShortner.Models.Entites;
using UrlShortner.Reposerties;
using UrlShortner.Utilites;

namespace UrlShortner.Services
{
    public class UrlServices(IVisitRepoesirey _visitRepoesirey, IShortUrlRepoesirey _shortUrlRepoesirey) : IUrlServices
    {
        private readonly string baseUrl = "http://tintlink/";

        public async Task<Link?> CreateShortLink(CreateShortLinkCommand command)
        {
            var hash = HashHElper.CreateHashHelper(command.OriginalLink);
            var link = new Link()
            {
                OriginalLink = command.OriginalLink,
                Hash = hash,
                ShortnerLink = $"{baseUrl}{hash}"
            };
            var shortLink = await _shortUrlRepoesirey.GetShortLinkByHash(hash);
            if (shortLink is not null)
                return shortLink;
            var response = await _shortUrlRepoesirey.AddLink(link);
            return response;
        }

        public async Task RecordVisit(ShortLinkQuery query)
        {
            var hash = query.ShortLink.Split("/").Last();

            var shortLink = await _shortUrlRepoesirey.GetShortLinkByHash(hash)
                            ?? throw new ArgumentException("Short Link Not Found");
            var visit = await _visitRepoesirey.GetVisitByQuery(new VisitQuery
            {
                Device = query.Device,
                LinkId = shortLink.Id,
                IpAddress = query.IpAddress
            });
            if (visit is null)
            {
                await _visitRepoesirey.AddVisit(new Visit
                {
                    LinkId = shortLink.Id,
                    IpAddress = query.IpAddress,
                    Device = query.Device,
                    Count = 1
                });
                return;
            }

            visit.Count++;
            visit.ModifiedDateTime = DateTime.Now;
            await _visitRepoesirey.UpdateVisit(visit);
        }
        public async Task<string> GetOriginalLink(ShortLinkQuery query)
        {
            var hash = query.ShortLink.Split("/").Last();

            var shortLink = await _shortUrlRepoesirey.GetShortLinkByHash(hash)
                            ?? throw new ArgumentException("Short Link Not Found");
            return shortLink.OriginalLink;
        }
    }
}
