using MassTransit;

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
                    cfg.Host(builder.Configuration["ConnectionStrings:MessageBroker"]);
                });
            });

            return builder;
        }
    }
}
