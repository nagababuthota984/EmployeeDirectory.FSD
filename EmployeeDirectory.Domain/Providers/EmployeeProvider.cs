
using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Concerns;
using EmployeeDirectory.Domain.Repositories;

namespace EmployeeDirectory.Domain.Providers
{
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly EmployeeRepository _empRepository;
        private readonly DepartmentRepository _deptRepository;
        private readonly OfficeRepository _officeRepository;
        private readonly JobTitleRepository _jobTitleRepository;
        public EmployeeProvider(EmployeeRepository employeeRepository, DepartmentRepository deptRepository, OfficeRepository officeRepository, JobTitleRepository jobTitleRepository)
        {
            _empRepository = employeeRepository;
            _deptRepository = deptRepository;
            _officeRepository = officeRepository;
            _jobTitleRepository = jobTitleRepository;
        }
        public async Task<int> AddEmployeeAsync(Employee employee)
        {

            //_empRepository.AddAsync(employee);
            return 1;
        }

        public Task<bool> DeleteEmployeeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return _empRepository.GetAllAsync().Result.Cast<Concerns.Employee>().ToList();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var x = await _empRepository.GetByIdAsync(id);
            Concerns.Employee emp = new Concerns.Employee
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PreferredName = x.PreferredName,
                Phone = x.Phone,
                JobTitle = x.JobTitle,
                Office = x.Office,
                Department = x.Department,
            };
            return emp;
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

        public Task<int> UpdateEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
