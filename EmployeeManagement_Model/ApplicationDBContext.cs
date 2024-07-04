using EmployeeManagement_Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement_Api.Models;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set;}
    public DbSet<Department> Departments { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed Department Table
        modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 1, DepartmentName = "It"});
        modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 2, DepartmentName = "HR"});
        modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 3, DepartmentName = "Finance"});
        modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 4, DepartmentName = "Networking"});

        // Seed Employee Table
        modelBuilder.Entity<Employee>().HasData(
            new Employee { EmployeeId = 1, Firstname = "John", Lastname = "Doe", DepartmentId = 1, BirthDate = new DateOnly(2024,4,7), Email = "John@gmail.com", Gender = Gender.Male, PhotoPath="" },
            new Employee { EmployeeId = 2, Firstname = "Jane", Lastname = "Smith", DepartmentId = 2, BirthDate = new DateOnly(2024,5,7), Email = "Jane@gmail.com", Gender = Gender.Male, PhotoPath="" },
            new Employee { EmployeeId = 3, Firstname = "Michael", Lastname = "Johnson", DepartmentId = 3, BirthDate = new DateOnly(2023,4,3), Email = "Michael@gmail.com", Gender = Gender.Other, PhotoPath="" },
            new Employee { EmployeeId = 4, Firstname = "Emily", Lastname = "Williams", DepartmentId = 4, BirthDate = new DateOnly(2023,4,8), Email = "Emily@gmail.com", Gender = Gender.Female, PhotoPath="" }
        );
    }
}
