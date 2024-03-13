using UrlShortner.Models.Entites;

namespace UrlShortner.Reposerties
{
    public interface IShortUrlRepoesirey
    {
        Task<Link?> AddLink(Link? link);
        Task<Link?> GetShortLinkByHash(string hash);
        Task<bool> SaveChanges();
        Task<Link> UpdateLink(Link link);

    }
}
