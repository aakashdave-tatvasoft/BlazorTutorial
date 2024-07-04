using EmployeeManagement_Model;
namespace EmployeeManagement_Web.Services;

public class EmployeeService : IEmployeeService
{
    private readonly HttpClient _httpClient;
    public EmployeeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Employee>> GetEmployeeListAsync(){
       return await _httpClient.GetFromJsonAsync<IEnumerable<Employee>>("api/employees");
    }

    public async Task<Employee> GetEmployeeAsync(int Id){
        return await _httpClient.GetFromJsonAsync<Employee>($"api/employees/{Id}");
    }
}
