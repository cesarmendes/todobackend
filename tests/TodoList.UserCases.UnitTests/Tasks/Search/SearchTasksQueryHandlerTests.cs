using Bogus;
using MassTransit;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Tasks.Repositories;
using TodoList.Infrastructure.Data.Pagination;
using TodoList.UserCases.Status.Search;
using TodoList.UserCases.Tasks.Delete;
using TodoList.UserCases.Tasks.Search;

namespace TodoList.UserCases.UnitTests.Tasks.Search
{
    public class SearchTasksQueryHandlerTests
    {
        [Fact]
        public async Task WhenTasksIsFound_Then_ReturnTasksPaginated()
        {
            //Arrange
            var size = 10;
            var fake = new Faker<Core.Tasks.Aggregates.Task>();
            var mockBus = new Mock<IBus>();
            var mockTaskRepository = new Mock<ITaskRepository>();
            var mockLogger = new Mock<ILogger<SearchTasksQueryHandler>>();

            mockTaskRepository.Setup(repo => repo.SearchAsync(It.IsAny<string?>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
                              .ReturnsAsync(new PaginatedList<Core.Tasks.Aggregates.Task>(fake.Generate(size),1, size, 1, size));

            var handler = new SearchTasksQueryHandler(mockTaskRepository.Object, mockLogger.Object);

            // Act
            var result = await handler.Handle(new SearchTasksQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
