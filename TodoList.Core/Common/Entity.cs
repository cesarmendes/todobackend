using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Core.Common
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; set; }
    }
}
