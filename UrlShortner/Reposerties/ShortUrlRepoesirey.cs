using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UrlShortner.Dbcontexts;
using UrlShortner.Models.Entites;

namespace UrlShortner.Reposerties
{
    public class ShortUrlRepoesirey(AppDbContext context) : IShortUrlRepoesirey
    {
        public async Task<Link?> AddLink(Link? link)
        {
            var response = await context.ShortLinks.AddAsync(link);
            await SaveChanges();
            return response.Entity;
        }

        public async Task<Link?> GetShortLinkByHash(string hash)
        {
            return await context.ShortLinks.FirstOrDefaultAsync(x => x.Hash == hash);
        }

        public async Task<bool> SaveChanges()
        {
            var rowsAffected = await context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<Link> UpdateLink(Link link)
        {
            var response = context.ShortLinks.Update(link);
            await SaveChanges();
            return response.Entity;
        }


    }
}
