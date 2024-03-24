namespace Task.Hub.Web.TaskEndpoints;

public record TaskRecord(Guid Uid, string Title, string Description, DateTime DueDate, bool IsCompleted);
