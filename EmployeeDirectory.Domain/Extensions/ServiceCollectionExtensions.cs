using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Data.DataConcerns;
using EmployeeDirectory.Domain.Providers;
using EmployeeDirectory.Domain.Repositories.EfCore;
using Microsoft.Extensions.DependencyInjection;
using static EmployeeDirectory.Data.Enums;

namespace EmployeeDirectory.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterProviders(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeProvider, EmployeeProvider>();
            services.AddTransient<IDepartmentProvider, DepartmentProvider>();
            services.AddTransient<IOfficeProvider, OfficeProvider>();
            services.AddTransient<IJobTitleProvider, JobTitleProvider>();
        }
        public static void RegisterRepositories(this IServiceCollection services, OrmType orm)
        {
            switch (orm)
            {
                case OrmType.Dapper:
                    services.AddScoped<IRepository<Employee>, Repositories.Dapper.EmployeeRepository>();
                    services.AddScoped<IRepository<Department>, Repositories.Dapper.DepartmentRepository>();
                    services.AddScoped<IRepository<JobTitle>, Repositories.Dapper.JobTitleRepository>();
                    services.AddScoped<IRepository<Office>, Repositories.Dapper.OfficeRepository>();
                    break;
                case OrmType.EfCore:
                    services.AddScoped<IRepository<Employee>, EmployeeRepository>();
                    services.AddScoped<IRepository<Department>, DepartmentRepository>();
                    services.AddScoped<IRepository<JobTitle>, JobTitleRepository>();
                    services.AddScoped<IRepository<Office>, OfficeRepository>();
                    break;
            }
        }
    }
}
