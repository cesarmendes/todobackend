using Microsoft.EntityFrameworkCore;
using TodoList.Core.Status.Aggregates;
using TodoList.Infrastructure.Data.Configurations;
using Task = TodoList.Core.Tasks.Aggregates.Task;

namespace TodoList.Infrastructure.Data.Contexts
{
    public class TodoListContext : DbContext
    {
        public TodoListContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Task>(new TaskConfiguration());
            modelBuilder.ApplyConfiguration<Status>(new StatusConfiguration());

            modelBuilder.Entity<Status>().HasData(StatusData());

            base.OnModelCreating(modelBuilder);
        }

        private IEnumerable<Status> StatusData()
        {
            return new List<Status>()
            {
                new Status(1, "A fazer"),
                new Status(2, "Em andamento"),
                new Status(3, "Revisando"),
                new Status(4, "Concluído"),
                new Status(5, "Bloqueado"),
                new Status(6, "Cancelado")
            };
        }
    }
}
