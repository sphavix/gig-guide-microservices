using Gigs.Domain.Entities;
using MediatR;

namespace Gigs.Application.Queries
{
    public class GetGigByIdQuery : IRequest<Gig>
    {
        public Guid Id { get; set; }
    }
}