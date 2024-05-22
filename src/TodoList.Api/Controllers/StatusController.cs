using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Transports.Status.Search;

namespace TodoList.Api.Controllers
{
    [ApiController]
    [Route("v1/api/status")]
    public class StatusController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] SearchStatusRequest request, CancellationToken token)
        {
            var result = await _mediator.Send(request.AsQuery());

            return Ok(result);
        }
    }
}
