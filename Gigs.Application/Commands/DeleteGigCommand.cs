using Gigs.Application.Responses;
using Gigs.Domain.Entities;
using MediatR;

namespace Gigs.Application.Commands
{
    public class DeleteGigCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}