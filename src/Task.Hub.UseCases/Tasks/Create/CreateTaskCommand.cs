using Task.Hub.UseCases.Result;
using MediatR;



namespace Task.Hub.UseCases.Tasks.Create;

public record CreateTaskCommand(string Title, string Description, DateTime DueDate) : IRequest<Result<Guid>>;


