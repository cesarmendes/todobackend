using Bogus;
using MassTransit;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Status.Repositories;
using TodoList.Core.Tasks.Repositories;
using TodoList.UserCases.Tasks.Get;
using TodoList.UserCases.Tasks.Update;

namespace TodoList.UserCases.UnitTests.Tasks.Get
{
    public class GetTaskQueryHandlerTests
    {
        [Fact]
        public async Task WhenTaskIsFound_ThenGetTask_ReturnTask()
        {
            //Arrange
            var fake = new Faker<Core.Tasks.Aggregates.Task>();

            var mockTaskRepository = new Mock<ITaskRepository>();
            var mockLogger = new Mock<ILogger<GetTaskQueryHandler>>();

            mockTaskRepository.Setup(repo => repo.GetAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                              .ReturnsAsync(fake.Generate());

            var handler = new GetTaskQueryHandler(mockTaskRepository.Object, mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetTaskQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
        }
    }
}
