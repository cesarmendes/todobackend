using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Transports.Tasks.Create;
using TodoList.Api.Transports.Tasks.Delete;
using TodoList.Api.Transports.Tasks.Get;
using TodoList.Api.Transports.Tasks.Update;

namespace TodoList.Api.Controllers
{
    [ApiController]
    [Route("v1/api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTaskResponse))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get([FromRoute] GetTaskRequest request, CancellationToken token)
        {
            var result = await _mediator.Send(request.AsQuery(), token);

            if (result is null)
                return NoContent();

            return Ok(GetTaskResponse.From(result));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateTaskResponse))]
        public async Task<IActionResult> Create([FromBody] CreateTaskRequest request, CancellationToken token)
        {
            var result = await _mediator.Send(request.AsCommand(), token);

            if (result.IsFailed)
            {

            }

            return Created(Request.GetDisplayUrl(), CreateTaskResponse.From(result.Value));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateTaskResponse))]
        public async Task<IActionResult> Update([FromBody] UpdateTaskRequest request, CancellationToken token)
        {
            var result = await _mediator.Send(request.AsCommand(), token);

            if (result.IsFailed) 
            {
            }

            return Ok(UpdateTaskResponse.From(result.Value));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteTaskResponse))]
        public async Task<IActionResult> Delete([FromBody] DeleteTaskRequest request, CancellationToken token)
        {
            var result = await _mediator.Send(request.AsCommand(), token);

            if (result.IsFailed)
            {
            }

            return Ok(DeleteTaskResponse.From(result.Value));
        }
    }
}
