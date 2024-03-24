using Task.Hub.UseCases.Result;
using MediatR;

namespace Task.Hub.UseCases.Tasks.Delete;

public record DeleteTaskCommand(Guid Uid) : IRequest<Result<Guid>>;