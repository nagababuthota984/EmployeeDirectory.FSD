
using EmployeeDirectory.Data.Contracts;

namespace EmployeeDirectory.Data.DataConcerns
{
    public class Department : Concerns.Department, IAuditable
    {
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
