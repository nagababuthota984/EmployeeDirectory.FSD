
using EmployeeDirectory.Data.Base;
using EmployeeDirectory.Data.Contracts;

namespace EmployeeDirectory.Data.DataConcerns
{
    public class Employee : BaseEntity<int>, IAuditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int JobTitleId { get; set; }
        public JobTitle JobTitle { get; set; }
        public decimal Salary { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

    }
}
