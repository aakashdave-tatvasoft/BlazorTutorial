using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement_Model;

public class Employee
{
    public int EmployeeId { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Email { get; set; }
    public DateOnly BirthDate { get; set; }
    public Gender Gender { get; set; }
    public int DepartmentId { get; set; }
    public string? PhotoPath { get; set; }
    [ForeignKey("DepartmentId")]
    public Department Department { get; set; }

}
