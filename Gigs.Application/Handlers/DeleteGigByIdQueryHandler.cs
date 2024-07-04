using Gigs.Application.Queries;
using Gigs.Domain.Repositories;
using MediatR;

namespace Gigs.Application.Handlers
{
    public class DeleteGigByIdQueryHandler : IRequestHandler<DeleteGigByIdQuery, bool>
    {
        private readonly IGigsRepository _gigsRepository;

        public DeleteGigByIdQueryHandler(IGigsRepository gigsRepository)
        {
            _gigsRepository = gigsRepository ?? throw new ArgumentNullException(nameof(gigsRepository));
        }

        public async Task<bool> Handle(DeleteGigByIdQuery query, CancellationToken cancellationToken)
        {
            return await _gigsRepository.DeleteGigAsync(query.Id);
        }
    }
}