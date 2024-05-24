using MediatR;
using Microsoft.Extensions.Logging;
using TodoList.Core.Common;
using TodoList.Core.Tasks.Repositories;
using Task = TodoList.Core.Tasks.Aggregates.Task;

namespace TodoList.UserCases.Tasks.Search
{
    //TODO: Adicionar paginação no retorno
    public record SearchTasksQueryHandler : IRequestHandler<SearchTasksQuery, IPaginatedList<Task>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger<SearchTasksQueryHandler> _logger;

        public SearchTasksQueryHandler(ITaskRepository taskRepository, ILogger<SearchTasksQueryHandler> logger)
        {
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public Task<IPaginatedList<Task>> Handle(SearchTasksQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Searching tasks by filter value: '{Title}'", request.Title);

            return _taskRepository.SearchAsync(request.Title, request.Page, request.Size, cancellationToken);
        }
    }
}
