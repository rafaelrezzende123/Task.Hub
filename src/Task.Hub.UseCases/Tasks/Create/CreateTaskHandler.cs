using MediatR;
using Task.Hub.Core.Entities.Interface;
using Task.Hub.UseCases.Result;


namespace Task.Hub.UseCases.Tasks.Create;

public class CreateTaskHandler(IDbContext _context) : IRequestHandler<CreateTaskCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var entity = Core.Entities.Task.Create(request.Title, request.Description, request.DueDate);
        await _context.Tasks.AddAsync(entity);
        await _context.SaveChangesAsync();

        return Result<Guid>.Success(entity.Uid);
    }
}
