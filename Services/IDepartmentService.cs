using Data;
using ViewModels;

namespace Services
{
    public interface IDepartmentService
    {
        List<Department> ShowAll();

        System.Threading.Tasks.Task CreateDepartmentAsync(DepartmentInputModel input);

        System.Threading.Tasks.Task DeleteDepartmentAsync(DepartmentInputModel input);

        int GetCount();
    }
}
