using EmployeeDirectory.Concerns;

namespace EmployeeDirectory.Application.Contracts
{
    public interface IDepartmentProvider
    {
        Task<Department> GetDepartmentByIdAsync(int id);
        Task<List<Department>> GetAllDepartmentsAsync();
        Task<int> AddDepartmentAsync(Department department);
        Task<int> UpdateDepartmentAsync(Department department);
        Task<bool> DeleteDepartmentAsync(int id);
    }
}
