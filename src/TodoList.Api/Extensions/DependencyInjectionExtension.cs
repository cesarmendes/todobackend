using System.Reflection;
using TodoList.Core.Tasks;

namespace TodoList.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static WebApplicationBuilder AddDependencies(this WebApplicationBuilder builder) 
        {
            builder.Services.AddMediatR(options => 
            {
                options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            //Repositories
            builder.Services.AddScoped<ITaskRepository, ITaskRepository>();

            return builder;
        }
    }
}
