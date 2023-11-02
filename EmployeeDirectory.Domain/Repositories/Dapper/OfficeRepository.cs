
using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Data.DataConcerns;

namespace EmployeeDirectory.Domain.Repositories.Dapper
{
    public class OfficeRepository : IRepository<Office>
    {
        public Task<int> AddAsync(Office entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Office entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Office>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Office> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Office entity)
        {
            throw new NotImplementedException();
        }
    }
}
