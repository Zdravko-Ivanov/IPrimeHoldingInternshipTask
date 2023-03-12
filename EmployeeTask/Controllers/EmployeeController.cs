using Data;
using EmployeeTask.Controllers;
using Microsoft.AspNetCore.Mvc;
using Services;
using ViewModels;

namespace Employees.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {

            this.employeeService = employeeService;
        }



        public IActionResult Index()
        {
            var employees = employeeService.ShowAll();
            var viewModel = new EmployeeInputModel { Employees = employees };
            return this.View(viewModel);
        }

        public IActionResult Create()
        {

            var viewModel = new EmployeeInputModel();
            //viewModel.Departments = this.employeeService.GetDepartments();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeInputModel input)
        {

            await this.employeeService.CreateEmployeeAsync(input);
            return this.RedirectToAction(nameof(this.Index));
        }

        public IActionResult Edit(string id)
        {
            var model = employeeService.GetEmployeeById(id);
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeInputModel input)
        {

            await this.employeeService.Update(input);
            return this.RedirectToAction(nameof(this.Index));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeInputModel input)
        {
            await this.employeeService.DeleteEmployeeAsync(input);
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
