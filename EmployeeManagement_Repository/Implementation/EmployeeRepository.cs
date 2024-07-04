using EmployeeManagement_Api.Models;
using EmployeeManagement_Model;
using EmployeeManagement_Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement_Repository.Implementation;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDBContext _dbContext;
    public EmployeeRepository(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Employee>> GetEmployeesAsync(){
        return await _dbContext.Employees.ToListAsync();
    }

    public async Task<Employee> AddEmployeeAsync(Employee employee){
        await _dbContext.Employees.AddAsync(employee);
        await _dbContext.SaveChangesAsync();
        return employee;
    }

    public async Task DeleteEmployeeAsync(int employeeId){
        var employee = await _dbContext.Employees.FindAsync(employeeId);
        if(employee!= null)
        {
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }
    }
    public async Task UpdateEmployeeAsync(Employee employee){
        _dbContext.Entry(employee).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
    public async Task<Employee?> GetEmployeeByIdAsync(int employeeId){
        return await _dbContext.Employees.FirstOrDefaultAsync(e=> e.EmployeeId==employeeId);
    }
    public async Task<List<Employee>> GetEmployeesByDepartmentAsync(int departmentId){
        return await _dbContext.Employees.Where(e=>e.DepartmentId == departmentId).ToListAsync();
    }

    public async Task<IEnumerable<Employee>> Search(string name, Gender? gender){
        return await _dbContext.Employees.Where(e=>
            e.Firstname.ToLower().Contains(name.ToLower()) || e.Lastname.ToLower().Contains(name.ToLower()) &&
            (gender == null || e.Gender == gender)).ToListAsync();
    }




}
