using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Task.Hub.Infrastructure.Data;

public static class AppDbContextExtensions
{

    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var commandDbConnection = configuration.GetConnectionString("SqlConnection");
        services.AddDbContext<TaskDbContext>(options => options.UseSqlite(commandDbConnection));
    }


}
