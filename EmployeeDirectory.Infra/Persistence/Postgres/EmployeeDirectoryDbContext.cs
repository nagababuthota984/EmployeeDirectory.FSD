using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Data.DataConcerns;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectory.Infra.Persistence.Postgres
{
    public class EmployeeDirectoryDbContext : DbContext, IApplicationDbContext
    {
        public EmployeeDirectoryDbContext(DbContextOptions<EmployeeDirectoryDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }

        public async Task<int> SaveContextChangesAsync()
        {
            return await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .HasPrincipalKey(d => d.Id);
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.JobTitle)
                .WithMany(j => j.Employees)
                .HasForeignKey(e => e.JobTitleId)
                .HasPrincipalKey(j => j.Id);
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Office)
                .WithMany(o => o.Employees)
                .HasForeignKey(e => e.OfficeId)
                .HasPrincipalKey(o => o.Id);
            modelBuilder.Entity<JobTitle>().HasData(new JobTitle
            {
                Id = 1,
                Title = "Software Developer",
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
                FirstName = "Sanjay",
                LastName = "Sahu",
                PreferredName = "Sanjay Sahu",
                Phone = "8464832529",
                Email = "s.sahu@gmail.com",
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
