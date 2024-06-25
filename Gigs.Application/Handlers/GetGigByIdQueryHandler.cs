using Gigs.Application.Queries;
using Gigs.Domain.Entities;
using Gigs.Infrastructure.Data;
using MediatR;

namespace Gigs.Application.Handlers
{
    public class GetGigByIdQueryHandler : IRequestHandler<GetGigByIdQuery, Gig>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetGigByIdQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Gig> Handle(GetGigByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Gigs.FindAsync(request.Id);
        }
    }
}