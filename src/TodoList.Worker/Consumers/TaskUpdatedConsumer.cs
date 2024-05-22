using MassTransit;
using TodoList.Core.Tasks.Events;

namespace TodoList.Worker.Consumers
{
    public record TaskUpdatedConsumer : IConsumer<TaskUpdatedEvent>
    {
        private readonly ILogger<TaskUpdatedConsumer> _logger;

        public TaskUpdatedConsumer(ILogger<TaskUpdatedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<TaskUpdatedEvent> context)
        {
            _logger.LogInformation("Task '{Title}' was updated, Id: {Id}", context.Message.Title, context.Message.Id);

            return context.ConsumeCompleted;
        }
    }
}
