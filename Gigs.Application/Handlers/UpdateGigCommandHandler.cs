using Gigs.Application.Commands;
using Gigs.Domain.Entities;
using Gigs.Domain.Repositories;
using MediatR;

namespace Gigs.Application.Handlers
{
    public class UpdateGigCommandHandler : IRequestHandler<UpdateGigCommand, bool>
    {
        public readonly IGigsRepository _gigsRepository;
        public UpdateGigCommandHandler(IGigsRepository gigsRepository)
        {
            _gigsRepository = gigsRepository ?? throw new ArgumentNullException(nameof(gigsRepository));
        }

        public async Task<bool> Handle(UpdateGigCommand command, CancellationToken cancellationToken)
        {
            var gig = await _gigsRepository.UpdateGigAsync(new Gig
            {
                Id = command.Id,
                Title = command.Title,
                Description = command.Description,
                Date = command.Date,
                Venue = command.Venue,
                Category = command.Category,
                City = command.City
            });

            return gig;
        }
    }
}