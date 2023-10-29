
using EmployeeDirectory.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeDirectory.Infra.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfigurationRoot config)
        {
            services.AddDbContext<EmployeeDirectoryDbContext>(options => options.UseNpgsql(config.GetConnectionString("Postgres")));
        }
    }
}
