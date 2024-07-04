using Gigs.Application.Responses;
using Gigs.Domain.Entities;
using MediatR;

namespace Gigs.Application.Queries
{
    public class GetGigsQuery : IRequest<IList<GigsResponse>>
    {
        
    }
}