using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Infrastructure.Data.Contexts
{
    public class TodoListContext : DbContext
    {
        public TodoListContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Task> MyProperty { get; set; }
    }
}
