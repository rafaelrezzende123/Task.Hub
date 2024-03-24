
namespace Task.Hub.Web.Endpoints.TaskEndpoints;
public class GetTaskRequest
{
    public const string Route = "/Tasks/{Uid}";
    public static string BuildRoute(string uid) => Route.Replace("{Uid}", uid);

    public Guid Uid { get; set; }
}
