using System.ComponentModel.DataAnnotations;
using TodoList.Infrastructure.Globalization;
using TodoList.UserCases.Tasks.Update;

namespace TodoList.Api.Transports.Tasks.Update
{
    public class UpdateTaskRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationInput), ErrorMessageResourceName = nameof(ValidationInput.Required))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationInput), ErrorMessageResourceName = nameof(ValidationInput.Required))]
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ValidationInput), ErrorMessageResourceName = nameof(ValidationInput.Required))]
        public int StatusId { get; set; }

        public UpdateTaskCommand AsCommand()
        {
            return new UpdateTaskCommand { Id = Id, Title = Title, Description = Description, StatusId = StatusId };
        }
    }
}
