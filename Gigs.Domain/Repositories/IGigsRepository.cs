using Gigs.Domain.Entities;

namespace Gigs.Domain.Repositories
{
    public interface IGigsRepository
    {
        Task<IEnumerable<Gig>> GetGigsAsync();
        Task<Gig> GetGigByIdAsync(Guid id);
        Task<Gig> CreateGigAsync(Gig gig);
        Task<bool> UpdateGigAsync(Gig gig);
        Task<bool> DeleteGigAsync(Guid id);
    }
}