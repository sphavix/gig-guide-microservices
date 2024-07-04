using Gigs.Application.Commands;
using Gigs.Application.Mappers;
using Gigs.Application.Responses;
using Gigs.Domain.Entities;
using Gigs.Domain.Repositories;
using Gigs.Infrastructure.Data;
using MediatR;

namespace Gigs.Application.Handlers
{
    public class CreateGigCommandHandler : IRequestHandler<CreateGigCommand, GigsResponse>
    {
        private readonly IGigsRepository _gigRepository;

        public CreateGigCommandHandler(IGigsRepository gigsRepository)
        {
            _gigRepository = gigsRepository ?? throw new ArgumentNullException(nameof(gigsRepository));
        }

        public async Task<GigsResponse> Handle(CreateGigCommand command, CancellationToken cancellationToken)
        {
            // Map the command to the domain entity {Gig}
            var gig = GigsMapper.Mapper.Map<Gig>(command);
            if (gig is null)
            {
                throw new ApplicationException("Issue mapper the command to domain entity");
            }

            // Add the mapped gig to the database
            var newGig = await _gigRepository.CreateGigAsync(gig);

            // Mapp the gig response back to the entity and return it as a response
            var gigResponse = GigsMapper.Mapper.Map<GigsResponse>(newGig);
            return gigResponse;
        }


    }
}