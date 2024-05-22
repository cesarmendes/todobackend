using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Tasks.Events;

namespace TodoList.Worker.Consumers
{
    public record TaskDeletedConsumer : IConsumer<TaskDeletedEvent>
    {
        private readonly ILogger<TaskDeletedConsumer> _logger;

        public TaskDeletedConsumer(ILogger<TaskDeletedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<TaskDeletedEvent> context)
        {
            _logger.LogInformation("Task '{Title}' was deleted, Id: {Id}", context.Message.Title, context.Message.Id);

            return context.ConsumeCompleted;
        }
    }
}
