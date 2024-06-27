using Gigs.Application.Commands;
using Gigs.Domain.Entities;
using Gigs.Infrastructure.Data;
using MediatR;

namespace Gigs.Application.Handlers
{
    public class CreateGigCommandHandler : IRequestHandler<CreateGigCommand>
    {
        private readonly ApplicationDbContext _context;

        public CreateGigCommandHandler(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Handle(CreateGigCommand command, CancellationToken cancellationToken)
        {
            _context.Gigs.Add(command.Gig);

            await _context.SaveChangesAsync();
        }


    }
}