using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.Api.Extensions
{
    public static class FluentResultExtension
    {
        public static IActionResult ResultToConflict<T>(this ControllerBase controller, Result<T> result)
        {
            ArgumentNullException.ThrowIfNull(result);

            return controller.Conflict(new ProblemDetails() 
            {
                Title = "One or more business validation errors occurred.",
                Status = StatusCodes.Status409Conflict,
                Detail = string.Join(", ", result.Errors.Select(error => error.Message)) 
            });
        }
    }
}
