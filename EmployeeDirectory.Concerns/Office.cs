
using EmployeeDirectory.Concerns.Base;

namespace EmployeeDirectory.Concerns
{
    public class Office : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}
