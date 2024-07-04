using Gigs.Application.Mappers;
using Gigs.Application.Queries;
using Gigs.Application.Responses;
using Gigs.Domain.Entities;
using Gigs.Domain.Repositories;
using Gigs.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gigs.Application.Handlers
{
    public class GetGigsQueryHandler : IRequestHandler<GetGigsQuery, IList<GigsResponse>>
    {
        private readonly IGigsRepository _gigsRepository;

        public GetGigsQueryHandler(IGigsRepository gigsRepository)
        {
            _gigsRepository = gigsRepository ?? throw new ArgumentNullException(nameof(gigsRepository));
        }

        public async Task<IList<GigsResponse>> Handle(GetGigsQuery query, CancellationToken cancellationToken)
        {
            var gigs = await _gigsRepository.GetGigsAsync();

            // Map the Gigs entity to a GigsResponse object
            var gigResponse = GigsMapper.Mapper.Map<IList<GigsResponse>>(gigs);
            return gigResponse;
        }
    }
}