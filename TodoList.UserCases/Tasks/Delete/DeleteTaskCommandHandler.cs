using FluentResults;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using TodoList.Core.Tasks.Events;
using TodoList.Core.Tasks.Repositories;
using Task = TodoList.Core.Tasks.Aggregates.Task;

namespace TodoList.UserCases.Tasks.Delete
{
    public record DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Result<Task>>
    {
        private readonly IBus _bus;
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger<DeleteTaskCommandHandler> _logger;

        public DeleteTaskCommandHandler(IBus bus, ITaskRepository taskRepository, ILogger<DeleteTaskCommandHandler> logger)
        {
            _bus = bus;
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public async Task<Result<Task>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Deleting Task with Id: '{Id}'.", request.Id);

            var task = await _taskRepository.GetAsync(request.Id);

            if (task is null) 
            {
                _logger.LogWarning("Task with Id: '{Id}' was not found, delete failed.", request.Id);

                return Result.Fail("A tarefa que precisa ser deletada não existe!");
            }

            await _taskRepository.DeleteAsync(task);

            _logger.LogInformation("Task with Id: '{Id}' and title: '{Title}' was deleted succesfully.", task.Id, task.Title);

            await _bus.Publish(new TaskDeletedEvent(task.Id, task.Title), cancellationToken);

            _logger.LogInformation("Task deleted event with Id: '{Id}' and title: '{Title}' was published", task.Id, task.Title);

            return Result.Ok(task);
        }
    }
}
