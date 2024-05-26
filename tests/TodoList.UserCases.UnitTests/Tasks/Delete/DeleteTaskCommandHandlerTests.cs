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
using TodoList.UserCases.Tasks.Create;
using TodoList.UserCases.Tasks.Delete;

namespace TodoList.UserCases.UnitTests.Tasks.Delete
{
    public class DeleteTaskCommandHandlerTests
    {
        [Fact]
        public async Task WhenTaskIsFound_ThenDeleteTask_ReturnResultOk() 
        {
            //Arrange
            var fake = new Faker<Core.Tasks.Aggregates.Task>();
            var mockBus = new Mock<IBus>();
            var mockTaskRepository = new Mock<ITaskRepository>();
            var mockLogger = new Mock<ILogger<DeleteTaskCommandHandler>>();

            mockTaskRepository.Setup(repo => repo.GetAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                              .ReturnsAsync(fake.Generate());
            mockTaskRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Core.Tasks.Aggregates.Task>(), It.IsAny<CancellationToken>()))
                              .ReturnsAsync(1);


            var handler = new DeleteTaskCommandHandler(mockBus.Object, mockTaskRepository.Object, mockLogger.Object);

            // Act
            var result = await handler.Handle(new DeleteTaskCommand(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task WhenTaskIsNotFound_ThenDontDeleteTask_ReturnResultError()
        {
            //Arrange
            var fake = new Faker<Core.Tasks.Aggregates.Task>();
            var mockBus = new Mock<IBus>();
            var mockTaskRepository = new Mock<ITaskRepository>();
            var mockLogger = new Mock<ILogger<DeleteTaskCommandHandler>>();

            mockTaskRepository.Setup(repo => repo.GetAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                              .ReturnsAsync(default(Core.Tasks.Aggregates.Task));
            mockTaskRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Core.Tasks.Aggregates.Task>(), It.IsAny<CancellationToken>()))
                              .ReturnsAsync(1);


            var handler = new DeleteTaskCommandHandler(mockBus.Object, mockTaskRepository.Object, mockLogger.Object);

            // Act
            var result = await handler.Handle(new DeleteTaskCommand(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsSuccess);
            Assert.NotEmpty(result.Errors);
        }
    }
}
