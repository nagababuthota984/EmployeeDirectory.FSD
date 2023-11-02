using Dapper;
using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Data.DataConcerns;

namespace EmployeeDirectory.Domain.Repositories.Dapper
{
    public class EmployeeRepository : BaseDapperRepository, IRepository<Employee>
    {
        public EmployeeRepository(IDapperContext context) : base(context) { }

        public Task<int> AddAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return (await _context.Connection.QueryAsync<Employee, Department, Office, JobTitle, Employee>("Select * from \"Employees\" e inner join \"Departments\" d on d.\"Id\" = e.\"DepartmentId\" inner join \"Offices\" o on o.\"Id\" = e.\"OfficeId\" inner join \"JobTitles\" j on j.\"Id\" = e.\"JobTitleId\"", (emp, dept, office, jt) =>
            {
                emp.Department = dept;
                emp.Office = office;
                emp.JobTitle = jt;
                return emp;
            })).ToList();
        }

        public Task<Employee> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
