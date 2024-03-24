namespace Task.Hub.Core.Entities.Query.Tasks;

public class TaskResponse
{
    public string Uid { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }

}
