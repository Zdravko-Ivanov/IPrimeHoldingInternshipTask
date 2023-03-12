using ViewModels;

namespace Services
{
    public interface ITaskService
    {

        List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> GetEmployees();

        List<Data.Task> ShowAll();
        TaskInputModel GetTaskById(int id);

        System.Threading.Tasks.Task Update(TaskInputModel input);

        System.Threading.Tasks.Task CreateTaskAsync(TaskInputModel input);

        System.Threading.Tasks.Task DeleteTaskAsync(TaskInputModel input);
        int GetCount();

        void Complete(string employeeId, int taskId);
    }
}
