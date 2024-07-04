using Gigs.Application.Mappers;
using Gigs.Application.Queries;
using Gigs.Application.Responses;
using Gigs.Domain.Repositories;
using MediatR;

namespace Gigs.Application.Handlers
{
    public class GetGigByIdQueryHandler : IRequestHandler<GetGigByIdQuery, GigsResponse>
    {
        private readonly IGigsRepository _gigsRepository;

        public GetGigByIdQueryHandler(IGigsRepository gigsRepository)
        {
            _gigsRepository = gigsRepository ?? throw new ArgumentNullException(nameof(gigsRepository));
        }

        public async Task<GigsResponse> Handle(GetGigByIdQuery query, CancellationToken cancellationToken)
        {
            var gig = await _gigsRepository.GetGigByIdAsync(query.Id);
            var gigResponse = GigsMapper.Mapper.Map<GigsResponse>(gig);
            return gigResponse;
        }
    }
}