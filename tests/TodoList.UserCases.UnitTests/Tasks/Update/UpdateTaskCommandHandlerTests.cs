using Bogus;
using MassTransit;
using Microsoft.Extensions.Logging;
using Moq;
using TodoList.Core.Status.Repositories;
using TodoList.Core.Tasks.Repositories;
using TodoList.UserCases.Tasks.Update;

namespace TodoList.UserCases.UnitTests.Tasks.Update
{
    public class UpdateTaskCommandHandlerTests
    {
        [Fact]
        public async Task WhenTaskIsFound_ThenUpdateTask_ReturnResultOk()
        {
            //Arrange
            var fake = new Faker<Core.Tasks.Aggregates.Task>();
            var fakeStatus = new Faker<Core.Status.Aggregates.Status>()
                .CustomInstantiator(f => new Core.Status.Aggregates.Status(f.Random.Int(), f.Lorem.Word()));

            var mockBus = new Mock<IBus>();
            var mockStatusRepository = new Mock<IStatusRepository>();
            var mockTaskRepository = new Mock<ITaskRepository>();
            var mockLogger = new Mock<ILogger<UpdateTaskCommandHandler>>();

            mockStatusRepository.Setup(repo => repo.GetAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                                .ReturnsAsync(fakeStatus.Generate());
            mockTaskRepository.Setup(repo => repo.GetAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                              .ReturnsAsync(fake.Generate());
            mockTaskRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Core.Tasks.Aggregates.Task>(), It.IsAny<CancellationToken>()))
                              .ReturnsAsync(1);


            var handler = new UpdateTaskCommandHandler(mockBus.Object, mockStatusRepository.Object, mockTaskRepository.Object, mockLogger.Object);

            // Act
            var result = await handler.Handle(new UpdateTaskCommand(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task WhenTaskIsNotFound_ThenDontUpdateTask_ReturnResultError()
        {
            //Arrange
            var fake = new Faker<Core.Tasks.Aggregates.Task>();
            var fakeStatus = new Faker<Core.Status.Aggregates.Status>()
                .CustomInstantiator(f => new Core.Status.Aggregates.Status(f.Random.Int(), f.Lorem.Word()));

            var mockBus = new Mock<IBus>();
            var mockStatusRepository = new Mock<IStatusRepository>();
            var mockTaskRepository = new Mock<ITaskRepository>();
            var mockLogger = new Mock<ILogger<UpdateTaskCommandHandler>>();

            mockStatusRepository.Setup(repo => repo.GetAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                                .ReturnsAsync(fakeStatus.Generate());
            mockTaskRepository.Setup(repo => repo.GetAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                              .ReturnsAsync(default(Core.Tasks.Aggregates.Task));
            mockTaskRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Core.Tasks.Aggregates.Task>(), It.IsAny<CancellationToken>()))
                              .ReturnsAsync(1);


            var handler = new UpdateTaskCommandHandler(mockBus.Object, mockStatusRepository.Object, mockTaskRepository.Object, mockLogger.Object);

            // Act
            var result = await handler.Handle(new UpdateTaskCommand(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsSuccess);
            Assert.NotEmpty(result.Errors);
        }

        [Fact]
        public async Task WhenStatusIsNotFound_ThenDontUpdateTask_ReturnResultError()
        {
            //Arrange
            var fake = new Faker<Core.Tasks.Aggregates.Task>();

            var mockBus = new Mock<IBus>();
            var mockStatusRepository = new Mock<IStatusRepository>();
            var mockTaskRepository = new Mock<ITaskRepository>();
            var mockLogger = new Mock<ILogger<UpdateTaskCommandHandler>>();

            mockStatusRepository.Setup(repo => repo.GetAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                                .ReturnsAsync(default(Core.Status.Aggregates.Status));
            mockTaskRepository.Setup(repo => repo.GetAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                              .ReturnsAsync(fake.Generate());
            mockTaskRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Core.Tasks.Aggregates.Task>(), It.IsAny<CancellationToken>()))
                              .ReturnsAsync(1);


            var handler = new UpdateTaskCommandHandler(mockBus.Object, mockStatusRepository.Object, mockTaskRepository.Object, mockLogger.Object);

            // Act
            var result = await handler.Handle(new UpdateTaskCommand(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsSuccess);
            Assert.NotEmpty(result.Errors);
        }
    }
}
