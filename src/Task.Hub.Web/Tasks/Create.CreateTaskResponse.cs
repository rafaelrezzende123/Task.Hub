namespace Task.Hub.Web.Endpoints.TaskEndpoints;
public class CreateTaskResponse(Guid uid)
{
    public string Uid { get; set; } = uid.ToString();
}

