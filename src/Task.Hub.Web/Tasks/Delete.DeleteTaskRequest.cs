namespace Task.Hub.Web.Endpoints.TaskEndpoints;
public record DeleteTaskRequest
{
  public const string Route = "/Tasks/{Uid}";
  public static string BuildRoute(string uid) => Route.Replace("{Uid}", uid);

  public Guid Uid { get; set; }
}
