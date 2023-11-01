

namespace EmployeeDirectory.Concerns
{
    public class Employee
    {
        public int Id { get; set; }
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
    }
}
