using MediatR;
using Microsoft.EntityFrameworkCore;
using Task.Hub.Core.Entities.Interface;
using Task.Hub.UseCases.Result;



namespace Task.Hub.UseCases.Tasks.Update;

public class UpdateTaskHandler(IDbContext _context) : IRequestHandler<UpdateTaskCommand, Result<TaskDTO>>
{
    public async Task<Result<TaskDTO>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Tasks.FirstOrDefaultAsync(a => a.Uid == request.Uid);
        if (entity == null)
            return Result<TaskDTO>.NotFound();

        entity.Update(request.Title, request.Description, request.DueDate, request.IsCompleted);
        await _context.SaveChangesAsync();


        var dto = new TaskDTO(entity.Uid, entity.Title, entity.Description, entity.DueDate, entity.IsCompleted);
        return Result<TaskDTO>.Success(dto);
    }
}
