using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Data.Contracts;
using EmployeeDirectory.Data.DataConcerns;

namespace EmployeeDirectory.Domain.Repositories
{
    public class OfficeRepository : IRepository<Office>
    {
        private readonly IApplicationDbContext _dbContext;
        public OfficeRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(Office entity)
        {
            if (entity is IAuditable)
            {
                entity.CreatedBy = "System";
                entity.CreatedOn = DateTime.UtcNow;
            }
            await _dbContext.Offices.AddAsync(entity);
            await _dbContext.SaveContextChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeleteAsync(Office entity)
        {
            try
            {if (entity is IAuditable)
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

        public async Task<List<Office>> GetAllAsync()
        {
            return _dbContext.Offices.ToList();
        }

        public async Task<Office> GetByIdAsync(int id)
        {
            return _dbContext.Offices.FirstOrDefault(office => office.Id == id);
        }

        public async Task<int> UpdateAsync(Office entity)
        {
            if (entity is IAuditable)
            {
                entity.ModifiedBy = "System";
                entity.ModifiedOn = DateTime.UtcNow;
            }
            _dbContext.Offices.Update(entity);
            await _dbContext.SaveContextChangesAsync();
            return entity.Id;   
        }
    }
}
