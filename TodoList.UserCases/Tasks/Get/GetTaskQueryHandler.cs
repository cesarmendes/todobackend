using MediatR;
using Microsoft.Extensions.Logging;
using TodoList.Core.Tasks;
using Task = TodoList.Core.Tasks.Task;


namespace TodoList.UserCases.Tasks.Get
{
    public record GetTaskQueryHandler : IRequestHandler<GetTaskQuery, Task?>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger<GetTaskQueryHandler> _logger;

        public GetTaskQueryHandler(ITaskRepository taskRepository, ILogger<GetTaskQueryHandler> logger)
        {
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public async Task<Task?> Handle(GetTaskQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Trying to get Task by Id: {Id}", request.Id);

            var task = await _taskRepository.GetAsync(request.Id, cancellationToken);

            _logger.LogInformation("Returning Task {Title} from Id: {Id}", task?.Title, request.Id);
            
            return task;
        }
    }
}
