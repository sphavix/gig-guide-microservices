using Gigs.Domain.Entities;
using Gigs.Domain.Repositories;
using Gigs.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Gigs.Infrastructure.Repositories
{
    public class GigsRepository : IGigsRepository
    {
        private readonly ApplicationDbContext _context;
        public GigsRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Gig>> GetGigsAsync()
        {
            return await _context.Gigs.ToListAsync();
        }

        public async Task<Gig> GetGigByIdAsync(Guid id)
        {
            return await _context.Gigs.Where(g => g.Id == id).FirstOrDefaultAsync().ConfigureAwait(true);
        }

        public async Task<Gig> CreateGigAsync(Gig gig)
        {
            var result = _context.Gigs.Add(gig);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return result.Entity;
        }

        public async Task<bool> UpdateGigAsync(Gig gig)
        {
            _context.Gigs.Update(gig);
            return await _context.SaveChangesAsync().ConfigureAwait(true) > 0;
        }

        public async Task<bool> DeleteGigAsync(Guid id)
        {
            var gig = await _context.Gigs.FindAsync(id).ConfigureAwait(true);
            _context.Gigs.Remove(gig);
            return await _context.SaveChangesAsync().ConfigureAwait(true) > 0;
        }
    }
}