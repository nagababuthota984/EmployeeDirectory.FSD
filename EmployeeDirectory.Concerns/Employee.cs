
using EmployeeDirectory.Concerns.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDirectory.Concerns
{
    public class Employee : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("Office")]
        public int OfficeId { get; set; }
        public virtual Office Office { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        [ForeignKey("JobTitle")]
        public int JobTitleId { get; set; }
        public virtual JobTitle JobTitle { get; set; }
        public decimal Salary { get; set; }
    }
}
