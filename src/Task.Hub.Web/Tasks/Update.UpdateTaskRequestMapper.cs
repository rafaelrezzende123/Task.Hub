using Task.Hub.UseCases.Tasks.Update;

namespace Task.Hub.Web.Endpoints.TaskEndpoints;

public static class UpdateTaskRequestMapper
{
    public static UpdateTaskCommand Mapper(UpdateTaskRequest request)
    {
        return new UpdateTaskCommand(request.Uid,
                                    request.Title,
                                    request.Description,
                                    request.DueDate,
                                    request.IsCompleted);
    }
}

