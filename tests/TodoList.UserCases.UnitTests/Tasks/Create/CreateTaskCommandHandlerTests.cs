using Bogus;
using MassTransit;
using Microsoft.Extensions.Logging;
using Moq;
using TodoList.Core.Status.Repositories;
using TodoList.Core.Tasks.Repositories;
using TodoList.Infrastructure.Data.Pagination;
using TodoList.UserCases.Tasks.Create;

namespace TodoList.UserCases.UnitTests.Tasks.Create
{
    public class CreateTaskCommandHandlerTests
    {
        [Fact()]
        public async Task WhenNoMatchingStatus_ThenReturnsErroResult()
        {
            // Arrange
            var fake = new Faker<CreateTaskCommand>()
            .RuleFor(p => p.StatusId, p => p.Random.Int())
            .RuleFor(p => p.Description, p => p.Lorem.Text())
            .RuleFor(p => p.Title, p => p.Lorem.Paragraph());

            var mockBus = new Mock<IBus>();
            var mockStatusRepository = new Mock<IStatusRepository>();
            var mockTaskRepository = new Mock<ITaskRepository>();
            var mockLogger = new Mock<ILogger<CreateTaskCommandHandler>>();

            mockStatusRepository.Setup(repo => repo.SearchAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
                                .ReturnsAsync(new PaginatedList<Core.Status.Aggregates.Status>(new List<Core.Status.Aggregates.Status>(), 0, 0, 1, 10));

            mockTaskRepository.Setup(repo => repo.InsertAsync(It.IsAny<Core.Tasks.Aggregates.Task>(), It.IsAny<CancellationToken>()))
                              .ReturnsAsync(0);


            var handler = new CreateTaskCommandHandler(mockBus.Object, mockStatusRepository.Object, mockTaskRepository.Object, mockLogger.Object);

            // Act
            var result = await handler.Handle(fake, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsSuccess);
            Assert.NotEmpty(result.Errors);
        }

        [Fact()]
        public async Task WhenMatchingStatus_ThenReturnOkResult() 
        {
            // Arrange
            var fakeCommand = new Faker<CreateTaskCommand>()
            .RuleFor(p => p.StatusId, p => p.Random.Int())
            .RuleFor(p => p.Description, p => p.Lorem.Text())
            .RuleFor(p => p.Title, p => p.Lorem.Paragraph());

            var mockBus = new Mock<IBus>();
            var mockStatusRepository = new Mock<IStatusRepository>();
            var mockTaskRepository = new Mock<ITaskRepository>();
            var mockLogger = new Mock<ILogger<CreateTaskCommandHandler>>();

            mockStatusRepository.Setup(repo => repo.GetAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                                .ReturnsAsync(new Core.Status.Aggregates.Status(1, "FASDf"));

            mockTaskRepository.Setup(repo => repo.InsertAsync(It.IsAny<Core.Tasks.Aggregates.Task>(), It.IsAny<CancellationToken>()))
                              .ReturnsAsync(1);


            var handler = new CreateTaskCommandHandler(mockBus.Object, mockStatusRepository.Object, mockTaskRepository.Object, mockLogger.Object);

            // Act
            var result = await handler.Handle(fakeCommand.Generate(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.Empty(result.Errors);
        }
    }
}
