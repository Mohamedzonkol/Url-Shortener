using Microsoft.EntityFrameworkCore;
using UrlShortner.Dbcontexts;
using UrlShortner.Models;
using UrlShortner.Models.Entites;

namespace UrlShortner.Reposerties
{
    public class VisitRepoesirey(AppDbContext context):IVisitRepoesirey
    {
        public async Task<Visit> AddVisit(Visit visit)
        {
            var response = await context.Visits.AddAsync(visit);
            await SaveChanges();
            return response.Entity;
        }

        public async Task<Visit?> GetVisitByQuery(VisitQuery query)
        {
            return await context.Visits.FirstOrDefaultAsync(x =>
                x.LinkId == query.LinkId &&
                x.IpAddress == query.IpAddress &&
                x.Device == query.Device);
        }

        public async Task<bool> SaveChanges()
        {
            var rowsAffected = await context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<Visit> UpdateVisit(Visit visit)
        {
            var response =  context.Visits.Update(visit);
            await SaveChanges();
            return response.Entity;
        }
    }
}
