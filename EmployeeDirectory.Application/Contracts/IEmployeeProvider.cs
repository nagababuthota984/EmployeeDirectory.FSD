using EmployeeDirectory.Concerns;

namespace EmployeeDirectory.Application.Contracts
{
    public interface IEmployeeProvider
    {
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<List<Employee>> GetEmployeesByDepartmentAsync();
        Task<List<Employee>> GetEmployeesByJobTitlesAsync();
        Task<List<Employee>> GetEmployeesByOfficeAsync();
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<int> AddEmployeeAsync(Employee employee);
        Task<int> UpdateEmployeeAsync(Employee employee);   
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
