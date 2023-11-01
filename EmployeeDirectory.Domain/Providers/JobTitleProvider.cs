
using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Concerns;
using Mapster;

namespace EmployeeDirectory.Domain.Providers
{
    public class JobTitleProvider : IJobTitleProvider
    {
        private readonly IRepository<Data.DataConcerns.JobTitle> _repository;
        public JobTitleProvider(IRepository<Data.DataConcerns.JobTitle> repository)
        {
            _repository = repository;
        }
        public async Task<int> AddJobTitleAsync(JobTitle jobTitle)
        {
            return await _repository.AddAsync(jobTitle.Adapt<Data.DataConcerns.JobTitle>());
        }

        public async Task<bool> DeleteJobTitleAsync(int id)
        {
            return await _repository.DeleteAsync(await _repository.GetByIdAsync(id));
        }

        public async Task<List<JobTitle>> GetAllJobTitlesAsync()
        {
            return (await _repository.GetAllAsync()).Cast<JobTitle>().ToList();
        }

        public async Task<JobTitle> GetJobTitleByIdAsync(int id)
        {
            return (await _repository.GetByIdAsync(id)).Adapt<JobTitle>();
        }

        public async Task<int> UpdateJobTitleAsync(JobTitle jobTitle)
        {
            return await _repository.UpdateAsync(jobTitle.Adapt<Data.DataConcerns.JobTitle>());
        }
    }
}
