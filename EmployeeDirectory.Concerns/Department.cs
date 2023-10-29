
using EmployeeDirectory.Concerns.Base;

namespace EmployeeDirectory.Concerns
{
    public class Department : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
