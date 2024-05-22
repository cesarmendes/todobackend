using MassTransit;
using TodoList.Core.Tasks.Events;

namespace TodoList.Api.Extensions
{
    public static class MassTransitExtension
    {
        public static WebApplicationBuilder AddMessageBroken(this WebApplicationBuilder builder)
        {
            builder.Services.AddMassTransit(options => 
            {
                options.SetKebabCaseEndpointNameFormatter();

                options.UsingRabbitMq((context, cfg) => 
                {
                    cfg.Publish<TaskCreatedEvent>();
                    cfg.Publish<TaskDeletedEvent>();
                    cfg.Publish<TaskUpdatedEvent>();

                    cfg.Host(builder.Configuration["ConnectionStrings:MessageBroker"]);
                });
            });

            return builder;
        }
    }
}
