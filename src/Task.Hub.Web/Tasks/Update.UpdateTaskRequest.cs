using System.ComponentModel.DataAnnotations;

namespace Task.Hub.Web.Endpoints.TaskEndpoints;


public class UpdateTaskRequest
{
    public const string Route = "/Tasks/{Uid}";
    public static string BuildRoute(string uid) => Route.Replace("{Uid}", uid);

    public Guid Uid { get; set; }



    [Required]
    public Guid TaskUid { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public DateTime DueDate { get; set; }
    [Required]
    public bool IsCompleted { get; set; }
}
