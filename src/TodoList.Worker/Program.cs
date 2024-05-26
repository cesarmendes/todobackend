using MassTransit;
using Serilog;
using TodoList.Worker;
using TodoList.Worker.Consumers;

IHost host = Host.CreateDefaultBuilder(args)
    .UseSerilog((hostContext, services, configuration) => {
        configuration.ReadFrom.Configuration(hostContext.Configuration);
    })
    .ConfigureServices((context, services) =>
    {
        services.AddMassTransit(options => 
        {
            options.SetKebabCaseEndpointNameFormatter();

            options.AddConsumer<TaskCreatedConsumer>();
            options.AddConsumer<TaskDeletedConsumer>();
            options.AddConsumer<TaskUpdatedConsumer>();

            options.UsingRabbitMq((ctx, cfg) => 
            {
                cfg.Host(context.Configuration["ConnectionStrings:MessageBroker"]);

                cfg.ConfigureEndpoints(ctx);

            });
        });

        //services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
