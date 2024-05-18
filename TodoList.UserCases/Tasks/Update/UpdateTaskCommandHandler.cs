using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;
using TodoList.Core.Tasks;
using Task = TodoList.Core.Tasks.Task;


namespace TodoList.UserCases.Tasks.Update
{
    public record UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Result<Task>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger<UpdateTaskCommandHandler> _logger;

        public UpdateTaskCommandHandler(ITaskRepository taskRepository, ILogger<UpdateTaskCommandHandler> logger)
        {
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

            task.Title = request.Title;
            task.Description = request.Description;

            await _taskRepository.UpdateAsync(task);

            _logger.LogInformation("Task with Id: '{Id}' and title: '{Title}' was updated succesfully.", task.Id, task.Title);

            return Result.Ok(task);
        }
    }
}
