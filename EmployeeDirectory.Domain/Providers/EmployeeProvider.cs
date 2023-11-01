
using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Concerns;
using EmployeeDirectory.Domain.Repositories;
using Mapster;
using MapsterMapper;
using System.Collections.Immutable;

namespace EmployeeDirectory.Domain.Providers
{
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly IRepository<Data.DataConcerns.Employee> _empRepository;
        private readonly IMapper _mapper;

        public EmployeeProvider(IMapper mapper, IRepository<Data.DataConcerns.Employee> employeeRepository)
        {
            _empRepository = employeeRepository;
        }
        public async Task<int> AddEmployeeAsync(Employee employee)
        {
            return await _empRepository.AddAsync(employee.Adapt<Data.DataConcerns.Employee>());
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            return await _empRepository.DeleteAsync(await _empRepository.GetByIdAsync(id));
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return (await _empRepository.GetAllAsync()).AsQueryable().ProjectToType<Employee>().ToList();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return (await _empRepository.GetByIdAsync(id)).Adapt<Employee>();
        }

        public Task<List<Employee>> GetEmployeesByDepartmentAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetEmployeesByJobTitlesAsync()
        {
            throw new NotImplementedException();

        }

        public Task<List<Employee>> GetEmployeesByOfficeAsync()
        {
            throw new NotImplementedException();

        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            return await _empRepository.UpdateAsync(employee.Adapt<Data.DataConcerns.Employee>());
        }
    }
}
