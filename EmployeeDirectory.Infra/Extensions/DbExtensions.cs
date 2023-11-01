
using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Infra.Persistence.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeDirectory.Infra.Extensions
{
    public static class DbExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfigurationRoot config)
        {
            services.AddDbContext<IApplicationDbContext,EmployeeDirectoryDbContext>(options => options.UseNpgsql(config.GetConnectionString("Postgres")));
        }
    }
}
