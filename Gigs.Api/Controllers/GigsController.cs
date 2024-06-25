using Gigs.Application.Queries;
using Gigs.Domain.Entities;
using Gigs.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Gigs.Api.Controllers
{
    public class GigsController : BaseApiController
    {
        private readonly IMediator _mediator;
        public GigsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<ActionResult<List<Gig>>> GetGigs()
        {
            var gigs = await _mediator.Send(new GetGigsQuery());
            return Ok(gigs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gig>> GetGig(Guid id)
        {
            var gig = await _mediator.Send(new GetGigByIdQuery { Id = id });
            return Ok(gig);
        }
    }
}