using Task.Hub.Core.Entities.Interface;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Dapper;

namespace Task.Hub.Infrastructure.Data;
public class TaskDbContext : DbContext, IDbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> dbContextOptions) : base(dbContextOptions) { }
    public DbSet<Core.Entities.Task> Tasks { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries()
                                   .Where(e => e.Entity is IAuditEntity &&  e.State == EntityState.Modified);


        foreach (var entityEntry in entries)
        {
 
            ((IAuditEntity)entityEntry.Entity).SetModifiedAt(DateTime.UtcNow);
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> GetRows<T>(string query, object? param)
    {
        using (var connection = this.Database.GetDbConnection())
        {
            return await connection.QueryAsync<T>(query, param);
        }
    }

    public async Task<T> GetRow<T>(string query, object? param)
    {
        using (var connection = this.Database.GetDbConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<T>(query, param);
        }
    }

}
