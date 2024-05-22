using TodoList.Core.Common;

namespace TodoList.Core.Tasks.Aggregates
{
    public class Task : Entity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
