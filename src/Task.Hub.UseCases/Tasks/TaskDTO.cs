
namespace Task.Hub.UseCases.Tasks;

public record TaskDTO(Guid Uid, string Title, string Description, DateTime DueDate, bool IsCompleted);