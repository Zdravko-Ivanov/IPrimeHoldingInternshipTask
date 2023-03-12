using Microsoft.AspNetCore.Mvc;
using Services;
using System.Diagnostics;
using ViewModels;

namespace Employees.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService deparmentService)
        {
            this.departmentService = deparmentService;
        }
        public IActionResult Index()
        {

            var departments = departmentService.ShowAll();
            var viewModel = new DepartmentInputModel { Departments = departments };
            return this.View(viewModel);
        }

        public IActionResult Create()
        {

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }
            await this.departmentService.CreateDepartmentAsync(input);
            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DepartmentInputModel input)
        {
            await this.departmentService.DeleteDepartmentAsync(input);
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
