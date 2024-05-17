using Microsoft.EntityFrameworkCore;
using TodoList.Infrastructure.Data.Contexts;

namespace TodoList.Api.Extensions
{
    public static class DatabaseExtension
    {
        public static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder) 
        {
            builder.Services.AddDbContext<TodoListContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:Database"], options => options.MigrationsAssembly(typeof(Program).Assembly.GetName().Name));
            });

            return builder;
        }
    }
}
