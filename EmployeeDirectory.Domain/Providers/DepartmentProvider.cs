
using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Concerns;
using Mapster;

namespace EmployeeDirectory.Domain.Providers
{
    public class DepartmentProvider : IDepartmentProvider
    {
        private readonly IRepository<Data.DataConcerns.Department> _departmentRepository;
        public DepartmentProvider(IRepository<Data.DataConcerns.Department> deptRepository)
        {
            _departmentRepository = deptRepository;
        }

        public async Task<int> AddDepartmentAsync(Department department)
        {
            Data.DataConcerns.Department entity = department.Adapt<Data.DataConcerns.Department>();
            return await _departmentRepository.AddAsync(entity);
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            return await _departmentRepository.DeleteAsync(await _departmentRepository.GetByIdAsync(id));
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return (await _departmentRepository.GetAllAsync()).Cast<Department>().ToList();
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return (await _departmentRepository.GetByIdAsync(id)).Adapt<Department>();
        }

        public async Task<int> UpdateDepartmentAsync(Department department)
        {
            return await _departmentRepository.UpdateAsync(department.Adapt<Data.DataConcerns.Department>());
        }
    }
}
