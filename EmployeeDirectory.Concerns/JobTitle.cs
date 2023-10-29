
using EmployeeDirectory.Concerns.Base;

namespace EmployeeDirectory.Concerns
{
    public class JobTitle : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
