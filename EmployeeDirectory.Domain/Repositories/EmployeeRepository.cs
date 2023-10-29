using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Data.DataConcerns;
using EmployeeDirectory.Infra.Persistence;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EmployeeDirectory.Domain.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly EmployeeDirectoryDbContext _dbContext;
        public EmployeeRepository(EmployeeDirectoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddAsync(Employee entity)
        {
            await _dbContext.Employees.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }
        public async Task<bool> DeleteAsync(Employee entity)
        {
            try
            {
                _dbContext.Employees.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return _dbContext.Employees.ToList();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return _dbContext.Employees.FirstOrDefault(emp => emp.Id == id);
        }

        public async Task<int> UpdateAsync(Employee entity)
        {
            _dbContext.Employees.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }
    }
}
