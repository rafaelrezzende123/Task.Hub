using FastEndpoints;
using Task.Hub.Web.Endpoints.TaskEndpoints;
using MediatR;
using TaskResult = System.Threading.Tasks.Task;

namespace Task.Hub.Web.TaskEndpoints;
public class Create(IMediator _mediator) : Endpoint<CreateTaskRequest, CreateTaskResponse>
{
    public override void Configure()
    {
        Post(CreateTaskRequest.Route);
        AllowAnonymous();
    }
    public override async TaskResult HandleAsync(CreateTaskRequest request, CancellationToken cancellationToken)
    {

        var result = await _mediator.Send(CreateTaskRequestMapper.Mapper(request));
        if (result.IsSuccess)
        {
            Response = new CreateTaskResponse(result);
            return;
        }

        return;

    }

}

