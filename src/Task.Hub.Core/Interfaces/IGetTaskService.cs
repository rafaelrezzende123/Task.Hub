using Task.Hub.Core.Entities.Query.Tasks;

namespace Task.Hub.Core.Interfaces
{
    public interface IGetTaskService
    {
        Task<TaskResponse> GetTask(Guid uid);
    }
}
