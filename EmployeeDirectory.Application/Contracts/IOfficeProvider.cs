using EmployeeDirectory.Concerns;

namespace EmployeeDirectory.Application.Contracts
{
    public interface IOfficeProvider
    {
        Task<List<Office>> GetAllOfficesAsync();
        Task<Office> GetOfficeByIdAsync(int id);   
        Task<int> AddOfficeAsync(Office office);
        Task<int> UpdateOfficeAsync(Office office);
        Task<bool> DeleteOfficeAsync(int id);
    }
}
