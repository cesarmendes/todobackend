using System.Reflection;
using TodoList.Core.Tasks.Repositories;
using TodoList.Infrastructure.Data.Repositories;
using TodoList.UserCases.Tasks.Create;

namespace TodoList.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static WebApplicationBuilder AddDependencies(this WebApplicationBuilder builder) 
        {
            builder.Services.AddMediatR(options => 
            {
                options.RegisterServicesFromAssembly(typeof(CreateTaskCommand).Assembly);
            });

            //Repositories
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();

            return builder;
        }
    }
}
