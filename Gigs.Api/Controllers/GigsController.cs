using Gigs.Application.Commands;
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

        [HttpGet]
        public async Task<IActionResult> GetGigs()
        {
            var gigs = await Mediator.Send(new GetGigsQuery());
            return Ok(gigs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gig>> GetGig(Guid id)
        {
            var gig = await Mediator.Send(new GetGigByIdQuery { Id = id });
            return Ok(gig);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGig(Gig gig)
        {
            return Ok(await Mediator.Send(gig));
        }
    }
}