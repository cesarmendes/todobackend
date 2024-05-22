using MassTransit;
using TodoList.Core.Tasks.Events;

namespace TodoList.Worker.Consumers
{
    public record TaskCreatedConsumer : IConsumer<TaskCreatedEvent>
    {
        private readonly ILogger<TaskCreatedConsumer> _logger;

        public TaskCreatedConsumer(ILogger<TaskCreatedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<TaskCreatedEvent> context)
        {
            _logger.LogInformation("Task '{Title}' was created, Id: {Id}", context.Message.Title, context.Message.Id);

            return context.ConsumeCompleted;
        }
    }
}
