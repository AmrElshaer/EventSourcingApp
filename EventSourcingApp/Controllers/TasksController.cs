using EventSourcingApp.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Task = EventSourcingApp.Core.Task;

namespace EventSourcingApp.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IAggregateRepository<Task, Guid> eventsService;

        public TasksController(IAggregateRepository<Task, Guid> eventsService)
        {
            this.eventsService = eventsService;
        }

        [HttpPost, Route("create")]
        public async Task<IActionResult> Create(string title, string createdBy)
        {

            var task = new Task(Guid.NewGuid(), title, createdBy);
            await eventsService.PersistAsync(task);
            return Ok(task.Id);
        }

        //[HttpPatch, Route("assign")]
        //public async Task<IActionResult> Assign(Guid id, [FromForm] string assignedTo)
        //{
        //	var aggregate = await _aggregateRepository.LoadAsync<Core.Task>(id);
        //	aggregate.Assign(assignedTo, "Ahmet KÜÇÜKOĞLU");

        //	await _aggregateRepository.SaveAsync(aggregate);

        //	return Ok();
        //}

        //[HttpPatch, Route("move")]
        //public async Task<IActionResult> Move(Guid id, [FromForm] BoardSections section)
        //{
        //	var aggregate = await _aggregateRepository.LoadAsync<Core.Task>(id);
        //	aggregate.Move(section, "Ahmet KÜÇÜKOĞLU");

        //	await _aggregateRepository.SaveAsync(aggregate);

        //	return Ok();
        //}

        //[HttpPatch, Route("complete")]
        //public async Task<IActionResult> Complete(Guid id)
        //{
        //	var aggregate = await _aggregateRepository.LoadAsync<Core.Task>(id);
        //	aggregate.Complete("Ahmet KÜÇÜKOĞLU");

        //	await _aggregateRepository.SaveAsync(aggregate);

        //	return Ok();
        //}
    }
}
