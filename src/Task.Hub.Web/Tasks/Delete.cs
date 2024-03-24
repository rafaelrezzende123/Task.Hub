using FastEndpoints;
using MediatR;
using Task.Hub.UseCases.Result;
using Task.Hub.UseCases.Tasks.Delete;
using Task.Hub.Web.Endpoints.TaskEndpoints;
namespace Task.Hub.Web.TaskEndpoints;
using TaskResult = System.Threading.Tasks.Task;

public class Delete(IMediator _mediator) : Endpoint<DeleteTaskRequest>
{
    public override void Configure()
    {
        Delete(DeleteTaskRequest.Route);
        AllowAnonymous();
    }

    public override async TaskResult HandleAsync(DeleteTaskRequest request, CancellationToken cancellationToken)
    {
        var command = new DeleteTaskCommand(request.Uid);

        var result = await _mediator.Send(command);

        if (result.Status == ResultStatus.NotFound)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        if (result.IsSuccess)
        {
            await SendNoContentAsync(cancellationToken);
        };
    }
}

