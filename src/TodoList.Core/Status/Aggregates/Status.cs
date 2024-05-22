using TodoList.Core.Common;

namespace TodoList.Core.Status.Aggregates
{
    public class Status : Entity<int>
    {
        public Status(int id, string name)
            : base(id)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
