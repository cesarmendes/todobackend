using Microsoft.EntityFrameworkCore;
using TodoList.Infrastructure.Data.Configurations;
using Task = TodoList.Core.Tasks.Task;

namespace TodoList.Infrastructure.Data.Contexts
{
    public class TodoListContext : DbContext
    {
        public TodoListContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Task>(new TaskConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
