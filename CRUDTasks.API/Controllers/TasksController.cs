using CRUDTasks.Application.Commands.CreateTasks;
using CRUDTasks.Application.Queries.GetAllTasks;
using DevFreela.Application.Commands.DeleteTasks;
using DevFreela.Application.Commands.UpdateTasks;
using DevFreela.Application.Queries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CRUDTasks.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllTaskssQuery = new GetAllTasksQuery();
            var tasks = await _mediator.Send(getAllTaskssQuery);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetTasksByIdQuery(id);
            var project = await _mediator.Send(query);

            if (project == null)
                return NotFound();

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTasksCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = id }, command);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateTasksCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteTasksCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
