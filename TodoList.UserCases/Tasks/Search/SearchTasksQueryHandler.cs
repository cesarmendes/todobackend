using MediatR;
using Microsoft.Extensions.Logging;
using TodoList.Core.Tasks.Repositories;
using Task = TodoList.Core.Tasks.Aggregates.Task;

namespace TodoList.UserCases.Tasks.Search
{
    //TODO: Adicionar paginação no retorno
    public record SearchTasksQueryHandler : IRequestHandler<SearchTasksQuery, List<Task>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger<SearchTasksQueryHandler> _logger;

        public SearchTasksQueryHandler(ITaskRepository taskRepository, ILogger<SearchTasksQueryHandler> logger)
        {
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public Task<List<Task>> Handle(SearchTasksQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Searching tasks by filter value: '{Title}'", request.Title);

            return _taskRepository.SearchAsync(request.Title, cancellationToken);
        }
    }
}
