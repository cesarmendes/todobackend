using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] int id) 
        {
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] int id)
        {
            return Ok(id);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            return Ok();
        }
    }
}
