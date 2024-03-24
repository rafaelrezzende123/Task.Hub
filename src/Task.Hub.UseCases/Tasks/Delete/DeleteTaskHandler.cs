using MediatR;
using Microsoft.EntityFrameworkCore;
using Task.Hub.Core.Entities.Interface;
using Task.Hub.UseCases.Result;

namespace Task.Hub.UseCases.Tasks.Delete;

public class DeleteTaskHandler(IDbContext _context) : IRequestHandler<DeleteTaskCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Tasks.FirstOrDefaultAsync(a => a.Uid == request.Uid);

        if (entity == null)
            return Result<Guid>.NotFound();

        entity.Disable();
        await _context.SaveChangesAsync();

        return Result<Guid>.Success(entity.Uid);
    }
}
