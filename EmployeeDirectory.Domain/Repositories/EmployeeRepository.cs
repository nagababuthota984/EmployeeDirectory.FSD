using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Data.Contracts;
using EmployeeDirectory.Data.DataConcerns;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectory.Domain.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly IApplicationDbContext _dbContext;
        public EmployeeRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddAsync(Employee entity)
        {
            if(entity is IAuditable)
            {
                entity.CreatedBy = "System";
                entity.CreatedOn = DateTime.UtcNow;
            }
            await _dbContext.Employees.AddAsync(entity);
            await _dbContext.SaveContextChangesAsync();
            return entity.Id;
        }
        public async Task<bool> DeleteAsync(Employee entity)
        {
            try
            {
                if (entity is IAuditable)
                {
                    entity.ModifiedBy = "System";
                    entity.ModifiedOn = DateTime.UtcNow;
                }
                entity.IsDeleted = true;
                await _dbContext.SaveContextChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return _dbContext.Employees.Include(e=>e.Department).Include(e=>e.Office).Include(e=>e.JobTitle).ToList();  
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return _dbContext.Employees.FirstOrDefault(emp => emp.Id == id);
        }

        public async Task<int> UpdateAsync(Employee entity)
        {
            if (entity is IAuditable)
            {
                entity.ModifiedBy = "System";
                entity.ModifiedOn = DateTime.UtcNow;
            }
            _dbContext.Employees.Update(entity);
            await _dbContext.SaveContextChangesAsync();
            return entity.Id;
        }
    }
}
