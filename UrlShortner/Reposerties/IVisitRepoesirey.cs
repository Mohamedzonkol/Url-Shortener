using UrlShortner.Models;
using UrlShortner.Models.Entites;

namespace UrlShortner.Reposerties
{
    public interface IVisitRepoesirey
    {
            Task<Visit> AddVisit(Visit  visit);
            Task<Visit?> GetVisitByQuery(VisitQuery query);
            Task<bool> SaveChanges();
            Task<Visit> UpdateVisit(Visit visit);

        
    }
}
