
using EmployeeDirectory.Data.Base;
using EmployeeDirectory.Data.Contracts;

namespace EmployeeDirectory.Data.DataConcerns
{
    public class Office : BaseEntity<int>, IAuditable
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public List<Employee> Employees { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
}
