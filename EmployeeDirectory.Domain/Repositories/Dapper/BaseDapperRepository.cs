
using EmployeeDirectory.Application.Contracts;

namespace EmployeeDirectory.Domain.Repositories.Dapper
{
    public abstract class BaseDapperRepository
    {
        public readonly IDapperContext _context;
        public BaseDapperRepository(IDapperContext context)
        {
            _context = context;
        }
    }
}
