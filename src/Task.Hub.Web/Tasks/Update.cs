using Task.Hub.Web.Endpoints.TaskEndpoints;
using FastEndpoints;
using MediatR;
using Task.Hub.UseCases.Result;
using TaskResult = System.Threading.Tasks.Task;

namespace Task.Hub.Web.TaskEndpoints;

public class Update(IMediator _mediator) : Endpoint<UpdateTaskRequest, TaskRecord>
{
    public override void Configure()
    {
        Put(UpdateTaskRequest.Route);
        AllowAnonymous();
    }
    public override async TaskResult HandleAsync(UpdateTaskRequest request, CancellationToken cancellationToken)
    {

        var result = await _mediator.Send(UpdateTaskRequestMapper.Mapper(request));

        if (result.Status == ResultStatus.NotFound)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        Response = UpdateTaskResponseMapper.Mapper(result.Value);

        return;
    }

}

