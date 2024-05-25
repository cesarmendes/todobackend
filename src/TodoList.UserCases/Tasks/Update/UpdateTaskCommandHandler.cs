using FluentResults;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using TodoList.Core.Status.Repositories;
using TodoList.Core.Tasks.Events;
using TodoList.Core.Tasks.Repositories;
using Task = TodoList.Core.Tasks.Aggregates.Task;


namespace TodoList.UserCases.Tasks.Update
{
    public record UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Result<Task>>
    {
        private readonly IBus _bus;
        private readonly IStatusRepository _statusRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger<UpdateTaskCommandHandler> _logger;

        public UpdateTaskCommandHandler(IBus bus, IStatusRepository statusRepository, ITaskRepository taskRepository, ILogger<UpdateTaskCommandHandler> logger)
        {
            _bus = bus;
            _statusRepository = statusRepository;
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public async Task<Result<Task>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Updating Task with Id: '{Id}'", request.Id);

            var task = await _taskRepository.GetAsync(request.Id);

            if(task is null) 
            {
                _logger.LogWarning("Task with Id: '{Id}' was not found, update failed.", request.Id);

                return Result.Fail("A tarefa que precisa ser atualizada não existe!");
            }

            var status = await _statusRepository.GetAsync(request.StatusId);

            if (status is null)
            {
                _logger.LogWarning("Status with Id: '{StatusId}' not found, update failed.", request.StatusId);

                return Result.Fail("O Id do status infomado não existe!");
            }

            task.Title = request.Title;
            task.Description = request.Description;
            task.StatusId = request.StatusId;
            task.StartDate = request.StartDate;
            task.TargetDate = request.TargetDate;
            task.UpdatedAt = DateTime.Now;

            await _taskRepository.UpdateAsync(task);

            _logger.LogInformation("Task with Id: '{Id}' and title: '{Title}' was updated succesfully.", task.Id, task.Title);

            await _bus.Publish(new TaskUpdatedEvent(task.Id, task.Title), cancellationToken);

            _logger.LogInformation("Task updated event with Id: '{Id}' and title: '{Title}' was published", task.Id, task.Title);

            return Result.Ok(task);
        }
    }
}
