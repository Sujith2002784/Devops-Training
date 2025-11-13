using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

namespace EmployeeDetails.Models
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Employee>().ToTable("Employee");

            // Specify precision and scale for Salary
            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasColumnType("decimal(18, 2)");

            // Seed data for Department
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, DeptName = "HR" },
                new Department { Id = 2, DeptName = "IT" },
                new Department { Id = 3, DeptName = "Finance" },
                new Department { Id = 4, DeptName = "Marketing" },
                new Department { Id = 5, DeptName = "Sales" }
            );

            // Seed data for Employee
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, EmpName = "John Doe", EmpAddress = "123 Main St", JoiningDate = new DateTime(2023, 1, 15), Salary = 50000.00m, PhoneNumber = "1234567890", DepartmentId = 1, IsActive = true },
                new Employee { Id = 2, EmpName = "Jane Smith", EmpAddress = "456 Elm St", JoiningDate = new DateTime(2023, 2, 20), Salary = 60000.00m, PhoneNumber = "0987654321", DepartmentId = 2, IsActive = true },
                new Employee { Id = 3, EmpName = "Alice Johnson", EmpAddress = "789 Oak St", JoiningDate = new DateTime(2023, 3, 25), Salary = 55000.00m, PhoneNumber = "1122334455", DepartmentId = 3, IsActive = false },
                new Employee { Id = 4, EmpName = "Bob Brown", EmpAddress = "321 Maple St", JoiningDate = new DateTime(2023, 4, 10), Salary = 45000.00m, PhoneNumber = "2233445566", DepartmentId = 4, IsActive = true },
                new Employee { Id = 5, EmpName = "Carol White", EmpAddress = "654 Pine St", JoiningDate = new DateTime(2023, 5, 5), Salary = 70000.00m, PhoneNumber = "3344556677", DepartmentId = 5, IsActive = true },
                new Employee { Id = 6, EmpName = "David Black", EmpAddress = "987 Cedar St", JoiningDate = new DateTime(2023, 6, 15), Salary = 52000.00m, PhoneNumber = "4455667788", DepartmentId = 1, IsActive = true },
                new Employee { Id = 7, EmpName = "Eve Green", EmpAddress = "159 Birch St", JoiningDate = new DateTime(2023, 7, 20), Salary = 48000.00m, PhoneNumber = "5566778899", DepartmentId = 2, IsActive = false },
                new Employee { Id = 8, EmpName = "Frank Blue", EmpAddress = "753 Oak St", JoiningDate = new DateTime(2023, 8, 25), Salary = 62000.00m, PhoneNumber = "6677889900", DepartmentId = 3, IsActive = true },
                new Employee { Id = 9, EmpName = "Grace Red", EmpAddress = "951 Elm St", JoiningDate = new DateTime(2023, 9, 30), Salary = 53000.00m, PhoneNumber = "7788990011", DepartmentId = 4, IsActive = true },
                new Employee { Id = 10, EmpName = "Hank Yellow", EmpAddress = "357 Maple St", JoiningDate = new DateTime(2023, 10, 10), Salary = 59000.00m, PhoneNumber = "8899001122", DepartmentId = 5, IsActive = false }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }
}
