using System.ComponentModel.DataAnnotations;

namespace Task.Hub.Web.Endpoints.TaskEndpoints;

public class CreateTaskRequest
{
    public const string Route = "/Tasks";

    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public DateTime DueDate { get; set; }


}

