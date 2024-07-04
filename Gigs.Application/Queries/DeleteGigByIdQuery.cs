using MediatR;

namespace Gigs.Application.Queries
{
    public class DeleteGigByIdQuery : IRequest<bool>
    {
        public Guid Id { get; }

        public DeleteGigByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}