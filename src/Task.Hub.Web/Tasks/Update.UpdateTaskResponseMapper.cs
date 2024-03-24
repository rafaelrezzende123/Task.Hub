using Task.Hub.UseCases.Tasks;
using Task.Hub.Web.TaskEndpoints;

namespace Task.Hub.Web.Endpoints.TaskEndpoints;

public static class UpdateTaskResponseMapper
{
    public static TaskRecord Mapper(TaskDTO dto)
    {
        return new TaskRecord(dto.Uid,
                                    dto.Title,
                                    dto.Description,
                                    dto.DueDate,
                                    dto.IsCompleted);
    }
}

