using MediatR;
using Microsoft.Extensions.Logging;
using TodoList.Core.Common;
using TodoList.Core.Status.Repositories;

namespace TodoList.UserCases.Status.Search
{
    public record SearchStatusQueryHandler : IRequestHandler<SearchStatusQuery, IPaginatedList<Core.Status.Aggregates.Status>>
    {
        private readonly IStatusRepository _statusRepository;
        private readonly ILogger<SearchStatusQueryHandler> _logger;

        public SearchStatusQueryHandler(IStatusRepository statusRepository, ILogger<SearchStatusQueryHandler> logger)
        {
            _statusRepository = statusRepository;
            _logger = logger;
        }

        public Task<IPaginatedList<Core.Status.Aggregates.Status>> Handle(SearchStatusQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Searching tasks by filter value: '{Title}'", request.Name);

            return _statusRepository.SearchAsync(request.Name, request.Page, request.Size, cancellationToken);
        }
    }
}
