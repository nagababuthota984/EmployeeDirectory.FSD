using EmployeeDirectory.Concerns;

namespace EmployeeDirectory.Application.Contracts
{
    public interface IDepartmentProvider
    {
        Department GetDepartmentByIdAsync(int id);
        List<Department> GetAllDepartmentsAsync();
        int AddDepartmentAsync(Department department);
        int UpdateDepartmentAsync(Department department);
        bool DeleteDepartmentAsync(int id);
    }
}
