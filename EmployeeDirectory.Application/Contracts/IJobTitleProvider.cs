
using EmployeeDirectory.Concerns;

namespace EmployeeDirectory.Application.Contracts
{
    public interface IJobTitleProvider
    {
        Task<List<JobTitle>> GetAllJobTitlesAsync();
        Task<JobTitle> GetJobTitleByIdAsync(int id);
        Task<int> AddJobTitleAsync(JobTitle jobTitle);
        Task<int> UpdateJobTitleAsync(JobTitle jobTitle);
        Task<bool> DeleteJobTitleAsync(int id);
    }
}
