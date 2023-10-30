
using EmployeeDirectory.Data.DataConcerns;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectory.Application.Contracts
{
    public interface IApplicationDbContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Office> Offices { get; set; }
        DbSet<JobTitle> JobTitles { get; set; }

        Task<int> SaveContextChangesAsync();

    }
}
