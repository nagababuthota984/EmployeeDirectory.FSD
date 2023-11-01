
using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Concerns;
using Mapster;

namespace EmployeeDirectory.Domain.Providers
{
    public class OfficeProvider : IOfficeProvider
    {
        private readonly IRepository<Data.DataConcerns.Office> _repository;
        public OfficeProvider(IRepository<Data.DataConcerns.Office> repository)
        {
            _repository = repository;
        }
        public async Task<int> AddOfficeAsync(Office office)
        {
            return await _repository.AddAsync(office.Adapt<Data.DataConcerns.Office>());
        }

        public async Task<bool> DeleteOfficeAsync(int id)
        {
            return await _repository.DeleteAsync(await _repository.GetByIdAsync(id));
        }

        public async Task<List<Office>> GetAllOfficesAsync()
        {
            return (await _repository.GetAllAsync()).Cast<Office>().ToList();
        }

        public async Task<Office> GetOfficeByIdAsync(int id)
        {
            return (await _repository.GetByIdAsync(id)).Adapt<Office>();
        }

        public async Task<int> UpdateOfficeAsync(Office office)
        {
            return await _repository.UpdateAsync(office.Adapt<Data.DataConcerns.Office>());
        }
    }
}
