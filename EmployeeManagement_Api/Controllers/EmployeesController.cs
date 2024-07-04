using EmployeeManagement_Model;
using EmployeeManagement_Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;
    public EmployeesController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Employee>), 200)]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(string), 500)]
    public async Task<IActionResult> GetEmployees()
    {
        try
        {
            return Ok(await _employeeRepository.GetEmployeesAsync());
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
        }
    }

    [HttpGet]
    [Route("{employeeId:int}")]
    [ProducesResponseType(typeof(Employee), 200)]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(string), 404)]
    [ProducesResponseType(typeof(string), 500)]
    public async Task<IActionResult> GetEmployee(int employeeId)
    {
        try
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);
            if (employee == null) return NotFound();
            return Ok(employee);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(Employee), 201)]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(string), 500)]
    public async Task<ActionResult<Employee>> CreateEmployeeAsync(Employee employee)
    {
        try
        {
            var createdEmployee = await _employeeRepository.AddEmployeeAsync(employee);

            if (createdEmployee == null)
            {
                return BadRequest("Unable to add the employee.");
            }

            return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId }, createdEmployee);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
        }
    }

    [HttpPut]
    [Route("{employeeId:int}")]
    [ProducesResponseType(typeof(Employee), 200)]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(string), 404)]
    [ProducesResponseType(typeof(string), 500)]
    public async Task<ActionResult<Employee>> UpdateEmployeeAsync(int employeeId, Employee updatedEmployee)
    {
        if (employeeId!= updatedEmployee.EmployeeId)
        {
            return BadRequest("Employee ID mismatch.");
        }
        try
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);
            if (employee == null) return NotFound();

            employee.Firstname = updatedEmployee.Firstname;
            employee.Lastname = updatedEmployee.Lastname;
            employee.Email = updatedEmployee.Email;
            employee.BirthDate = updatedEmployee.BirthDate;
            employee.Gender = updatedEmployee.Gender;
            employee.DepartmentId = updatedEmployee.DepartmentId;
            employee.PhotoPath = updatedEmployee.PhotoPath;

            await _employeeRepository.UpdateEmployeeAsync(employee);

            return Ok(employee);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
        }
    }

    [HttpDelete]
    [Route("{employeeId:int}")]
    [ProducesResponseType(typeof(string), 204)]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(string), 404)]
    [ProducesResponseType(typeof(string), 500)]
    public async Task<IActionResult> DeleteEmployeeAsync(int employeeId)
    {
        try
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);
            if (employee == null) return NotFound();

            await _employeeRepository.DeleteEmployeeAsync(employeeId);

            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
        }
    }

    [Route("search")]
    [HttpGet]
    [ProducesResponseType(typeof(List<Employee>), 200)]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(string), 500)]
    public async Task<ActionResult<IEnumerable<Employee>>> Search(string name, Gender? gender){
        try
        {
            return Ok(await _employeeRepository.Search(name, gender));
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
        }
    }
}
