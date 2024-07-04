using MediatR;

namespace Gigs.Application.Commands
{
    public class UpdateGigCommand : IRequest<bool>
    {
         public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
    }
}