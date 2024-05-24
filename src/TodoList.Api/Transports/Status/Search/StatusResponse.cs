
namespace TodoList.Api.Transports.Status.Search
{
    public class StatusResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static StatusResponse From(Core.Status.Aggregates.Status status)
        {
            return new StatusResponse
            {
                Id = status.Id,
                Name = status.Name,
            };
        }

        public static List<StatusResponse> From(IEnumerable<Core.Status.Aggregates.Status> status)
        {
            var result = new List<StatusResponse>();

            foreach (var s in status)
            {
                result.Add(From(s));
            }

            return result;
        }
    }
}
