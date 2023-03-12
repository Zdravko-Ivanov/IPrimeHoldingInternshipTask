namespace Services
{
    using Data;
    using ViewModels;

    public interface IEmployeeService
    {
        List<Employee> ShowAll();

        System.Threading.Tasks.Task CreateEmployeeAsync(EmployeeInputModel input);

        EmployeeInputModel GetEmployeeById(string id);

        System.Threading.Tasks.Task Update(EmployeeInputModel input);

        System.Threading.Tasks.Task DeleteEmployeeAsync(EmployeeInputModel input);

        int GetCount();

        Dictionary<string,int> GetTop5();

        List<Employee> GetTop5Salarys();

        List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> GetDepartments();
    }
}
