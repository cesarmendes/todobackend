using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Core.Tasks.Events
{
    public record TaskCreatedEvent
    {
        public TaskCreatedEvent(int id, string title)
        {
            Id = id; 
            Title = title;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
    }
}
