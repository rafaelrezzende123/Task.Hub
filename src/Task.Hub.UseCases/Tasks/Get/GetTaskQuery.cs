using Task.Hub.UseCases.Result;
using MediatR;
using Task.Hub.Core.Entities.Interface;

namespace Task.Hub.UseCases.Tasks.Get;

public record GetTaskQuery(Guid Uid) : IRequest<Result<TaskDTO>>;
