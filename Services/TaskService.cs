using Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;
using ViewModels;

namespace Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext context;

        public TaskService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Complete(string employeeId, int taskId)
        {
            var task = this.context.Tasks.FirstOrDefault(x => x.Id == taskId);
            var employee = this.context.Employees.FirstOrDefault(x => x.Id == employeeId);
            task.IsCompleted = true;
            task.CompletedOn = DateTime.UtcNow;
            employee.CompletedTasks = employee.CompletedTasks + 1;
            this.context.Update(task);
            this.context.Update(employee);
            this.context.SaveChanges();
        }

        public async System.Threading.Tasks.Task CreateTaskAsync(TaskInputModel input)
        {
            var task = new Data.Task
            {
                Title = input.Title,
                Description = input.Description,
                DueDate = input.DueDate,
                EmployeeId = input.EmployeeId,

            };
            this.context.Tasks.Add(task);
            await this.context.SaveChangesAsync();

        }

        public async System.Threading.Tasks.Task DeleteTaskAsync(TaskInputModel input)
        {
            var task = this.context.Tasks.Where(x => x.Id == input.Id).FirstOrDefault();
            this.context.Remove(task);
            await this.context.SaveChangesAsync();
        }

        public int GetCount()
        {
            return this.context.Tasks.Count();
        }

        public List<SelectListItem> GetEmployees()
        {
            var employees = new List<SelectListItem>();
            foreach (var employee in context.Employees)
            {
                var temp = new SelectListItem { Text = employee.FullName, Value = employee.Id };
                employees.Add(temp);
            }
            return employees;
        }

        public TaskInputModel GetTaskById(int id)
        {
            var task = this.context.Tasks.Where(x => x.Id == id).FirstOrDefault();
            var model = new TaskInputModel
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                EmployeeId = task.EmployeeId

            };
            return model;

        }

        public List<Data.Task> ShowAll()
        {
            return this.context.Tasks.OrderBy(x => x.Title).ToList();
        }

        public async System.Threading.Tasks.Task Update(TaskInputModel input)
        {
            var task = this.context.Tasks.Where(x => x.Id == input.Id).FirstOrDefault();

            task.Title = input.Title;
            task.Description = input.Description;
            task.DueDate = input.DueDate;
            task.EmployeeId = input.EmployeeId;

            this.context.Update(task);
            await this.context.SaveChangesAsync();
        }
    }
}
