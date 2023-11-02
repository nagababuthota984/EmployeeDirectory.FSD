using Dapper;
using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Data.DataConcerns;

namespace EmployeeDirectory.Domain.Repositories.Dapper
{
    public class DepartmentRepository : IRepository<Department>
    {
        private readonly IDapperContext _context;
        public DepartmentRepository(IDapperContext dapperContext)
        {
            _context = dapperContext;
        }

        public Task<int> AddAsync(Department entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Department entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return (await _context.Connection.QueryAsync<Department>("Select * from Departments")).ToList();
        }

        public Task<Department> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
