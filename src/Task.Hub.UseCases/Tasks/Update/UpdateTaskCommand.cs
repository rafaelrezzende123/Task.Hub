using Task.Hub.UseCases.Result;
using MediatR;


namespace Task.Hub.UseCases.Tasks.Update;

public record UpdateTaskCommand(Guid Uid, string Title, string Description, DateTime DueDate, bool IsCompleted) : IRequest<Result<TaskDTO>>;
