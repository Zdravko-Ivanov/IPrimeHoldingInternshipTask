using Data;
using EmployeeTask.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Diagnostics;
using ViewModels;

namespace EmployeeTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly ITaskService taskService;
        private readonly IDepartmentService departmentService;
        private readonly ApplicationDbContext context;

        public HomeController(IEmployeeService employeeService, ITaskService taskService, IDepartmentService departmentService)
        {
            this.employeeService = employeeService;
            this.taskService = taskService;
            this.departmentService = departmentService;
            this.context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                EmployeeCount = employeeService.GetCount(),
                TaskCount = taskService.GetCount(),
                DepartmentCount = departmentService.GetCount(),
            };
            viewModel.TopEmployees = employeeService.GetTop5();
            viewModel.TopSalarys = employeeService.GetTop5Salarys();
            return View(viewModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}