using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gigs.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        // Create the context for MediatR instead of calling DI everytime the instance is used.
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;
    }
}