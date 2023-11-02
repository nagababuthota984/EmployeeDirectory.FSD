using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Data.Contracts;
using EmployeeDirectory.Data.DataConcerns;

namespace EmployeeDirectory.Domain.Repositories.EfCore
{
    public class DepartmentRepository : IRepository<Department>
    {
        private readonly IApplicationDbContext _dbContext;
        public DepartmentRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddAsync(Department entity)
        {
            if (entity is IAuditable)
            {
                entity.CreatedBy = "System";
                entity.CreatedOn = DateTime.UtcNow;
            }
            await _dbContext.Departments.AddAsync(entity);
            await _dbContext.SaveContextChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeleteAsync(Department entity)
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
            if (entity is IAuditable)
            {
                entity.ModifiedBy = "System";
                entity.ModifiedOn = DateTime.UtcNow;
            }
            _dbContext.Departments.Update(entity);
            await _dbContext.SaveContextChangesAsync();
            return entity.Id;
        }
    }
}
