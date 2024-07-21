using Gigs.Application.Commands;
using Gigs.Application.Queries;
using Gigs.Application.Responses;
using Gigs.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace Gigs.Api.Controllers
{
    public class GigsController : BaseApiController
    {

        [HttpGet]
        //[Route("GetAllGigs")]
        [ProducesResponseType(typeof(IList<GigsResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<GigsResponse>>> GetGigs()
        {
            var gigs = await Mediator.Send(new GetGigsQuery());
            return Ok(gigs);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GigsResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GigsResponse>> GetGig(Guid id)
        {
            var gig = new GetGigByIdQuery(id);
            var result = await Mediator.Send(gig);
            return Ok(result);
        }

        [HttpPost]
        //[Route("CreateGig")]
        [ProducesResponseType(typeof(GigsResponse),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<GigsResponse>> CreateGig([FromBody] CreateGigCommand command)
        {
            var gig = await Mediator.Send(command);
            return Ok(gig);
        }

        [HttpPut]
        //[Route("UpdateGig")]
        [ProducesResponseType(typeof(GigsResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateGig([FromBody] UpdateGigCommand command)
        {
            var gig = await Mediator.Send(command);
            return Ok(gig);
        }

        [HttpDelete("{id}")]
        //[Route("{id}", Name = "DeleteGig")]
        public async Task<IActionResult> DeleteGig(Guid id)
        {
            var result = await Mediator.Send(new DeleteGigCommand { Id = id});
            return Ok(result);
        }
    }
}