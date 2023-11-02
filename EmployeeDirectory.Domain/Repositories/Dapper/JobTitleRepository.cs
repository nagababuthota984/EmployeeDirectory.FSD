
using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Data.DataConcerns;

namespace EmployeeDirectory.Domain.Repositories.Dapper
{
    public class JobTitleRepository : IRepository<JobTitle>
    {
        public Task<int> AddAsync(JobTitle entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(JobTitle entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<JobTitle>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<JobTitle> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(JobTitle entity)
        {
            throw new NotImplementedException();
        }
    }
}
