using FluentResults;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using TodoList.Core.Status.Repositories;
using TodoList.Core.Tasks.Events;
using TodoList.Core.Tasks.Repositories;
using Task = TodoList.Core.Tasks.Aggregates.Task;

namespace TodoList.UserCases.Tasks.Create
{
    internal class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Result<Task>>
    {
        private readonly IBus _bus;
        private readonly IStatusRepository _statusRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger<CreateTaskCommandHandler> _logger;

        public CreateTaskCommandHandler(IBus bus, IStatusRepository statusRepository, ITaskRepository taskRepository, ILogger<CreateTaskCommandHandler> logger)
        {
            _bus = bus;
            _statusRepository = statusRepository;
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public async Task<Result<Task>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating Task with title: '{Title}'", request.Title);

            var status = await _statusRepository.GetAsync(request.StatusId);

            if (status is null) 
            {
                _logger.LogWarning("Status with Id: '{StatusId}' not found, create failed.", request.StatusId);

                return Result.Fail("O Id do status infomado não existe!");
            }

            var task = new Task() 
            {
                StatusId = status.Id,
                Title = request.Title,
                Description = request.Description,
                StartDate = request.StartDate,      
                TargetDate = request.TargetDate,
                CreatedAt = DateTime.Now
            };

            await _taskRepository.InsertAsync(task);

            _logger.LogInformation("Task with Id: '{Id}' and title: '{Title}' was created succesfully.",task.Id, task.Title);

            await _bus.Publish(new TaskCreatedEvent(task.Id, task.Title), cancellationToken);

            _logger.LogInformation("Task created event with Id: '{Id}' and title: '{Title}' was published", task.Id, task.Title);

            return Result.Ok(task);
        }
    }
}
