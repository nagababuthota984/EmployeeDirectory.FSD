
using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Infra.Persistence.Postgres.Dapper;
using EmployeeDirectory.Infra.Persistence.Postgres.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeDirectory.Infra.Extensions
{
    public static class DbExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfigurationRoot config)
        {
            //Ef Core
            services.AddDbContext<IApplicationDbContext,EmployeeDirectoryDbContext>(options => options.UseNpgsql(config.GetConnectionString("Postgres")));
            //Dapper
            services.AddSingleton<IDapperContext, DapperContext>();
        }
    }
}
