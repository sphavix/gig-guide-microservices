using Gigs.Application.Commands;
using Gigs.Domain.Repositories;
using MediatR;

namespace Gigs.Application.Handlers
{
    public class DeleteGigCommandHandler: IRequestHandler<DeleteGigCommand, bool>
    {
        private readonly IGigsRepository _gigsRepository;
        public DeleteGigCommandHandler(IGigsRepository gigsRepository)
        {
            _gigsRepository = gigsRepository ?? throw new ArgumentNullException(nameof(gigsRepository));
        }

        public async Task<bool> Handle(DeleteGigCommand command, CancellationToken cancellationToken)
        {
            var gig = await _gigsRepository.GetGigByIdAsync(command.Id);
            if (gig == null)
            {
                return default;
            }

            await _gigsRepository.DeleteGigAsync(gig.Id);
            return true;
        } 
    }
}