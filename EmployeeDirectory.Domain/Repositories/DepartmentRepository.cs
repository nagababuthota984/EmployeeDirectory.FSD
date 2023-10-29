
using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Data.DataConcerns;
using EmployeeDirectory.Infra.Persistence;

namespace EmployeeDirectory.Domain.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        private readonly EmployeeDirectoryDbContext _dbContext;
        public DepartmentRepository(EmployeeDirectoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddAsync(Department entity)
        {
            await _dbContext.Departments.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeleteAsync(Department entity)
        {
            try
            {
                _dbContext.Departments.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return _dbContext.Departments.ToList();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return _dbContext.Departments.FirstOrDefault(x => x.Id == id);
        }

        public async Task<int> UpdateAsync(Department entity)
        {
            _dbContext.Departments.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }
    }
}
