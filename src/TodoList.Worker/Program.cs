using MassTransit;
using TodoList.Worker;
using TodoList.Worker.Consumers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddMassTransit(options => 
        {
            options.AddConsumer<TaskCreatedConsumer>();
            options.AddConsumer<TaskDeletedConsumer>();
            options.AddConsumer<TaskUpdatedConsumer>();

            options.UsingRabbitMq((ctx, cfg) => 
            {
                cfg.Host(context.Configuration["ConnectionStrings:MessageBroker"]);

                cfg.ConfigureEndpoints(ctx);

            });
        });

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
