
using EmployeeDirectory.Concerns;

namespace EmployeeDirectory.Application.Contracts
{
    public interface IJobTitleProvider
    {
        List<JobTitle> GetAllJobTitlesAsync();
        JobTitle GetJobTitleByIdAsync(int id);
        int AddJobTitleAsync(JobTitle jobTitle);
        int UpdateJobTitleAsync(JobTitle jobTitle);
        bool DeleteJobTitleAsync(int id);
    }
}
