using System.ComponentModel.DataAnnotations;
using TodoList.UserCases.Tasks.Update;

namespace TodoList.Api.Transports.Tasks.Update
{
    public class UpdateTaskRequest
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public UpdateTaskCommand AsCommand()
        {
            return new UpdateTaskCommand { Id = Id, Title = Title, Description = Description };
        }
    }
}
