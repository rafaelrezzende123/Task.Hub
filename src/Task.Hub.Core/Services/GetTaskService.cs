using Task.Hub.Core.Entities.Interface;
using Task.Hub.Core.Entities.Query.Tasks;
using Task.Hub.Core.Interfaces;


namespace Task.Hub.Core.Services;

public class GetTaskService(IDbContext _context) : IGetTaskService
{
    public async Task<TaskResponse> GetTask(Guid uid)
    {
        return await _context.GetRow<TaskResponse>(SqlTaskConstants.GetTask, new { Uid = uid, Active = true });
    }
}

