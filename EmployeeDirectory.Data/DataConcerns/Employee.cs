
using EmployeeDirectory.Data.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDirectory.Data.DataConcerns
{
    public class Employee : Concerns.Employee, IAuditable
    {
        [ForeignKey("Office")]
        public int OfficeId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
