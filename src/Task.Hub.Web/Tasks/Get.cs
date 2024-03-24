using Task.Hub.Web.Endpoints.TaskEndpoints;
using FastEndpoints;
using MediatR;
using Task.Hub.UseCases.Result;
using Task.Hub.UseCases.Tasks.Get;
using TaskResult = System.Threading.Tasks.Task;


namespace Task.Hub.Web.TaskEndpoints;

public class Get(IMediator _mediator) : Endpoint<GetTaskRequest, TaskRecord>
{
    public override void Configure()
    {
        Get(GetTaskRequest.Route);
        AllowAnonymous();
    }
    public override async TaskResult HandleAsync(GetTaskRequest request, CancellationToken cancellationToken)
    {
        var command = new GetTaskQuery(request.Uid);

        var result = await _mediator.Send(command);

        if (result.Status == ResultStatus.NotFound)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        if (result.IsSuccess)
        {
            Response = GetTaskResponseMapper.Mapper(result.Value);
        }
    }

}

