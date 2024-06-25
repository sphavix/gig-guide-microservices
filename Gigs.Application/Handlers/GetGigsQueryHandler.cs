using Gigs.Application.Queries;
using Gigs.Domain.Entities;
using Gigs.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gigs.Application.Handlers
{
    public class GetGigsQueryHandler : IRequestHandler<GetGigsQuery, List<Gig>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetGigsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Gig>> Handle(GetGigsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Gigs.ToListAsync();
        }
    }
}