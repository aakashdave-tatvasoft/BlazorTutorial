using EmployeeManagement_Model;

namespace EmployeeManagement_Repository.Interface;

public interface IDepartmentRepository
{
    Task<IEnumerable<Department>> GetAllDepartmentsAsync();
    Task<Department?> GetDepartmentByIdAsync(int id);
}
