using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Data.Contracts;
using EmployeeDirectory.Data.DataConcerns;

namespace EmployeeDirectory.Domain.Repositories
{
    public class JobTitleRepository : IRepository<JobTitle>
    {
        private readonly IApplicationDbContext _dbContext;
        public JobTitleRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddAsync(JobTitle entity)
        {
            if (entity is IAuditable)
            {
                entity.CreatedBy = "System";
                entity.CreatedOn = DateTime.UtcNow;
            }
            await _dbContext.JobTitles.AddAsync(entity);
            await _dbContext.SaveContextChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeleteAsync(JobTitle entity)
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

        public async Task<List<JobTitle>> GetAllAsync()
        {
            return _dbContext.JobTitles.ToList();
        }

        public async Task<JobTitle> GetByIdAsync(int id)
        {
            return _dbContext.JobTitles.FirstOrDefault(jobTitle => jobTitle.Id == id);
        }

        public async Task<int> UpdateAsync(JobTitle entity)
        {
            if (entity is IAuditable)
            {
                entity.ModifiedBy = "System";
                entity.ModifiedOn = DateTime.UtcNow;
            }
            _dbContext.JobTitles.Update(entity);
            await _dbContext.SaveContextChangesAsync();
            return entity.Id;
        }
    }
}
