using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;
using TodoList.Core.Tasks;
using Task = TodoList.Core.Tasks.Task;

namespace TodoList.UserCases.Tasks.Delete
{
    public record DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Result<Task>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger<DeleteTaskCommandHandler> _logger;

        public DeleteTaskCommandHandler(ITaskRepository taskRepository, ILogger<DeleteTaskCommandHandler> logger)
        {
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

            return Result.Ok(task);
        }
    }
}
