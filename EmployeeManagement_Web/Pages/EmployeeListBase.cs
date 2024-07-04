using EmployeeManagement_Model;
using EmployeeManagement_Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement_Web.Pages;

public class EmployeeListBase : ComponentBase
{
    [Inject]
    public IEmployeeService EmployeeService { get; set; }
    
    public IEnumerable<Employee> Employees { get; set; }
    
    public string ErrorMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Employees = await EmployeeService.GetEmployeeListAsync();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }
}
