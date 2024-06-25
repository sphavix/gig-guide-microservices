using Gigs.Domain.Entities;
using MediatR;

namespace Gigs.Application.Queries
{
    public class GetGigsQuery : IRequest<List<Gig>>
    {
        
    }
}