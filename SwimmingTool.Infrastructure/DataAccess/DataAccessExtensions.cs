using Microsoft.Extensions.DependencyInjection;

namespace SwimmingTool.Infrastructure.DataAccess;

public static class DataAccessExtensions
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection serviceDescriptors, string connectionString)
    {
        return serviceDescriptors.AddSqlServer<AppDbContext>(connectionString);
    }
}
