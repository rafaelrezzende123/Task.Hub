using Task.Hub.UseCases.Tasks.Create;

namespace Task.Hub.Web.Endpoints.TaskEndpoints;

public static class CreateTaskRequestMapper
{
    public static CreateTaskCommand Mapper(CreateTaskRequest request)
    {
        return new CreateTaskCommand(request.Title,
                                    request.Description,
                                    request.DueDate);
    }
}

