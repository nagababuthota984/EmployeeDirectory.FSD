
using EmployeeDirectory.Data.DataConcerns;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace EmployeeDirectory.Infra.Persistence
{
    public class EmployeeDirectoryDbContext : DbContext
    {
        public EmployeeDirectoryDbContext(DbContextOptions<EmployeeDirectoryDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                        .HasDiscriminator<string>("dept_type")
                        .HasValue<Department>("dept_data_concern");
            modelBuilder.Entity<Office>()
                        .HasDiscriminator<string>("office_type")
                        .HasValue<Office>("office_data_concernt");
            modelBuilder.Entity<JobTitle>()
                        .HasDiscriminator<string>("jobtitle_type")
                        .HasValue<JobTitle>("jobtitle_data_concern");
            modelBuilder.Entity<JobTitle>().HasData(new JobTitle
            {
                Id = 1,
                Name = "Software Developer",
                Description = "Software developer with more than 1 year of experience.",
                CreatedBy = "System",
                CreatedOn = DateTime.UtcNow,
                ModifiedBy = "System",
                ModifiedOn = DateTime.UtcNow,
            });
            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = 1,
                Name = "Product Engineering",
                Description = "Product Engineering",
                CreatedBy = "System",
                CreatedOn = DateTime.UtcNow,
                ModifiedBy = "System",
                ModifiedOn = DateTime.UtcNow,
            });
            modelBuilder.Entity<Office>().HasData(new Office
            {
                Id = 1,
                Name = "India",
                Location = "India",
                Description = "Tezo digital office. Hyderabad, India.",
                CreatedBy = "System",
                CreatedOn = DateTime.UtcNow,
                ModifiedBy = "System",
                ModifiedOn = DateTime.UtcNow,
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                FirstName = "Nagababu",
                LastName = "Thota",
                PreferredName = "Nagababu Thota",
                Phone = "8464832529",
                Email = "nagababuthota593@gmail.com",
                Salary = 59900,
                OfficeId = 1,
                DepartmentId = 1,
                JobTitleId = 1,
                CreatedBy = "System",
                CreatedOn = DateTime.UtcNow,
                ModifiedBy = "System",
                ModifiedOn = DateTime.UtcNow,
            });
        }
    }
}
