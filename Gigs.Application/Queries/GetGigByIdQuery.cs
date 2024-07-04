using Gigs.Application.Responses;
using MediatR;

namespace Gigs.Application.Queries
{
    public class GetGigByIdQuery : IRequest<GigsResponse>
    {
        public Guid Id { get; set; }

        public GetGigByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}