using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Data.DataConcerns;
using EmployeeDirectory.Infra.Persistence;
using System.Linq.Expressions;

namespace EmployeeDirectory.Domain.Repositories
{
    public class OfficeRepository : IRepository<Office>
    {
        private readonly EmployeeDirectoryDbContext _dbContext;
        public OfficeRepository(EmployeeDirectoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(Office entity)
        {
            await _dbContext.Offices.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeleteAsync(Office entity)
        {
            try
            {
                _dbContext.Offices.Remove(entity);
                await _dbContext.SaveChangesAsync();
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
            _dbContext.Offices.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;   
        }
    }
}
