using Gigs.Domain.Entities;
using MediatR;

namespace Gigs.Application.Commands
{
    public class CreateGigCommand : IRequest
    {
        public Gig Gig { get; set; }
    }
}