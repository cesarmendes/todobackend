using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Common;

namespace TodoList.Core.Tasks
{
    public class Task : Entity<int>
    {
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
