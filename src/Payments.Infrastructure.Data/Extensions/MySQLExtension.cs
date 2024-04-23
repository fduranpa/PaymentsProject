using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Payments.Infrastructure.Data.Context;

namespace Payments.Infrastructure.Data.Extensions
{
    public static class MySQLExtension
    {
        public static IServiceCollection AddDbContextAuthorization(this IServiceCollection services, string connectionString)
        {
            ServerVersion version = ServerVersion.AutoDetect(connectionString);
            services.AddDbContext<AuthorizationContext>(
                    options => options.UseMySql(connectionString, version)
                );

            return services;
        }
    }
}
