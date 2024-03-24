using Task.Hub.UseCases.Result;
using MediatR;
using Task.Hub.Core.Interfaces;


namespace Task.Hub.UseCases.Tasks.Get;

public class GetTaskHandler(IGetTaskService _service) : IRequestHandler<GetTaskQuery, Result<TaskDTO>>
{
    public async Task<Result<TaskDTO>> Handle(GetTaskQuery request, CancellationToken cancellationToken)
    {
        var result = await _service.GetTask(request.Uid);
        if (result is null)
            return Result<TaskDTO>.NotFound();

        return Result<TaskDTO>.Success(new TaskDTO(Guid.Parse(result.Uid),
                                                    result.Title,
                                                    result.Description,
                                                    result.DueDate,
                                                    result.IsCompleted));

    }
}
