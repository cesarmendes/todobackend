using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
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

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(1, int.MaxValue)]
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
