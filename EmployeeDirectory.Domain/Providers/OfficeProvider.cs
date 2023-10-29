
using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Concerns;

namespace EmployeeDirectory.Domain.Providers
{
    public class OfficeProvider : IOfficeProvider
    {
        public Task<int> AddOfficeAsync(Office office)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOfficeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Office>> GetAllOfficesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Office> GetOfficeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateOfficeAsync(Office office)
        {
            throw new NotImplementedException();
        }
    }
}
