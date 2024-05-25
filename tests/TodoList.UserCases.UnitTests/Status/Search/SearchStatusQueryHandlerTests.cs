using Microsoft.Extensions.Logging;
using Moq;
using TodoList.Core.Status.Repositories;
using TodoList.Infrastructure.Data.Pagination;
using TodoList.UserCases.Status.Search;

namespace TodoList.UserCases.UnitTests.Status.Search
{
    public class SearchStatusQueryHandlerTests
    {
        [Fact()]
        public async Task Handle_WhenNoMatchingStatusesFound_ReturnsEmptyPaginatedList()
        {
            // Arrange
            var mockStatusRepository = new Mock<IStatusRepository>();
            mockStatusRepository.Setup(repo => repo.SearchAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
                                .ReturnsAsync(new PaginatedList<Core.Status.Aggregates.Status>(new List<Core.Status.Aggregates.Status>(), 0, 0, 1, 10));

            var mockLogger = new Mock<ILogger<SearchStatusQueryHandler>>();

            var handler = new SearchStatusQueryHandler(mockStatusRepository.Object, mockLogger.Object);

            // Act
            var result = await handler.Handle(new SearchStatusQuery { Name = null, Page = 1, Size = 10 }, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.Equal(10, result.PageSize);
            Assert.Equal(0, result.TotalItems);
        }
    }
}
