using EmployeeDirectory.Concerns;

namespace EmployeeDirectory.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string PreferredName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public JobTitle JobTitle { get; set; }
        public Department Department { get; set; }
        public Office Office { get; set; }

    }
}
