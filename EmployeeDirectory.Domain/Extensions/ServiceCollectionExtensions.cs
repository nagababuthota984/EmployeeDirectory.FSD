using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Data.DataConcerns;
using EmployeeDirectory.Domain.Providers;
using EmployeeDirectory.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

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
        public static void RegisterRepositories(this IServiceCollection services) 
        {
            services.AddScoped<IRepository<Employee>, EmployeeRepository>();
            services.AddScoped<IRepository<Department>, DepartmentRepository>();
            services.AddScoped<IRepository<JobTitle>, JobTitleRepository>();
            services.AddScoped<IRepository<Office>, OfficeRepository>();
        }   
    }
}
