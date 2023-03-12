using Data;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Web.WebPages.Html;
using ViewModels;

namespace Employees.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }
        public IActionResult Index()
        {
            var tasks = taskService.ShowAll();
            var viewModel = new TaskInputModel { Tasks = tasks };
            viewModel.Employees = this.taskService.GetEmployees();
            return this.View(viewModel);

        }
        public IActionResult Create()
        {
            var viewModel = new TaskInputModel();
            viewModel.Employees = this.taskService.GetEmployees();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskInputModel input)
        {

            await this.taskService.CreateTaskAsync(input);
            return this.RedirectToAction(nameof(this.Index));
        }


        public IActionResult Edit(int id)
        {
            var viewModel = taskService.GetTaskById(id);

            viewModel.Employees = this.taskService.GetEmployees();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskInputModel input)
        {

            await this.taskService.Update(input);
            return this.RedirectToAction(nameof(this.Index));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(TaskInputModel input)
        {
            await this.taskService.DeleteTaskAsync(input);
            return this.RedirectToAction(nameof(this.Index));
        }

        public IActionResult Complete(string employeeId, int taskId)
        {
            taskService.Complete(employeeId, taskId);

            return this.RedirectToAction(nameof(this.Index));

        }
    }
}
