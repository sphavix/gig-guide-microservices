using Gigs.Application.Responses;
using MediatR;

namespace Gigs.Application.Commands
{
    public class CreateGigCommand : IRequest<GigsResponse>
    {
        public string Title { get; set; } 
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
    }
}