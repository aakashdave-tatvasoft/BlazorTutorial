using EmployeeManagement_Model;
using EmployeeManagement_Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EmployeeManagement_Web.Pages;

public class EmployeeDetailsBase : ComponentBase
{
    public Employee Employee { get; set; } = new Employee();
    [Inject]
    public IEmployeeService EmployeeService {get; set;}
    [Parameter]
    public string Id { get; set; }
    public string ErrorMessage { get; set; }

    protected string Coordniates { get; set; }
    protected string BtnText {get; set;} = "Hide Footer";
    protected bool ToggleBtn {get; set;} = false;

    protected string CSS_HideFooter {get; set;} = "";


    protected override async Task OnInitializedAsync()
    {
        try
        {
            Employee = await EmployeeService.GetEmployeeAsync(int.Parse(Id));
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    protected void Mouse_Click(MouseEventArgs e){
        Coordniates = $"X = {e.ClientX} & Y = {e.ClientY}";
    }
    protected void Toggle_Footer(){
        if(ToggleBtn == true){
            BtnText = "Show Footer";
            ToggleBtn = false;
            CSS_HideFooter = "hide-footer";
        }else{
            BtnText = "Hide Footer";
            ToggleBtn = true;
            CSS_HideFooter = "";
        }
    }
}
