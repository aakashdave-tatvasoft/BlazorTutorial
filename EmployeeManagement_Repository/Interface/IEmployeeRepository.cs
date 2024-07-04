using EmployeeManagement_Model;

namespace EmployeeManagement_Repository.Interface;


public interface IEmployeeRepository
{
    Task<List<Employee>> GetEmployeesAsync();
    Task<Employee> AddEmployeeAsync(Employee employee);
    Task DeleteEmployeeAsync(int employeeId);
    Task UpdateEmployeeAsync(Employee employee);
    Task<Employee?> GetEmployeeByIdAsync(int employeeId);
    Task<List<Employee>> GetEmployeesByDepartmentAsync(int departmentId);
    Task<IEnumerable<Employee>> Search(string name, Gender? gender);
}
