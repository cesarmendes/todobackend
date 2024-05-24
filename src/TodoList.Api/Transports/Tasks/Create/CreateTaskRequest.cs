using System.ComponentModel.DataAnnotations;
using TodoList.Infrastructure.Globalization;
using TodoList.UserCases.Tasks.Create;

namespace TodoList.Api.Transports.Tasks.Create
{
    public record CreateTaskRequest
    {
        public CreateTaskRequest()
        {
            Title = string.Empty;
            Description = string.Empty;
        }

        [Required(ErrorMessageResourceType = typeof(ValidationInput), ErrorMessageResourceName = nameof(ValidationInput.Required))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationInput), ErrorMessageResourceName = nameof(ValidationInput.Required))]
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ValidationInput), ErrorMessageResourceName = nameof(ValidationInput.Required))]
        public int StatusId { get; set; }

        public CreateTaskCommand AsCommand() 
        { 
            return new CreateTaskCommand() 
            {
                Title = Title,
                Description = Description,
                StatusId = StatusId
            }; 
        }
    }
}
