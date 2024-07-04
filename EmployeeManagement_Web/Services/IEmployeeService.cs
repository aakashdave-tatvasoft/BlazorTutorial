using EmployeeManagement_Model;

namespace EmployeeManagement_Web.Services;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetEmployeeListAsync();
    Task<Employee> GetEmployeeAsync(int Id);
}
