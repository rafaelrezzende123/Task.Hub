
using Microsoft.EntityFrameworkCore;

namespace Task.Hub.Core.Entities.Interface
{
    public interface IDbContext
    {
        DbSet<Task> Tasks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetRows<T>(string query, object? param);
        Task<T> GetRow<T>(string query, object? param);
    }
}
