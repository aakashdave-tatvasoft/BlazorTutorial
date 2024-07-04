using EmployeeManagement_Api.Models;
using EmployeeManagement_Model;
using EmployeeManagement_Repository.Interface;
using Microsoft.EntityFrameworkCore;
namespace EmployeeManagement_Repository.Implementation;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly ApplicationDBContext _applicationDBContext;
    public DepartmentRepository(ApplicationDBContext applicationDBContext)
    {
        _applicationDBContext = applicationDBContext;
    }

    public async Task<IEnumerable<Department>> GetAllDepartmentsAsync(){
        var departments = await _applicationDBContext.Departments.ToListAsync();
        return departments;
    }
    public async Task<Department?> GetDepartmentByIdAsync(int id){
        var department = await _applicationDBContext.Departments.FirstOrDefaultAsync(x => x.DepartmentId == id);
        return department ?? null;
    }
}
