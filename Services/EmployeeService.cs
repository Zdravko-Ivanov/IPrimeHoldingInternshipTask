using Data;
using MegaGraphics.Services.Mapping;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Mapping;
using System.Linq;
using ViewModels;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext context;

        public EmployeeService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async System.Threading.Tasks.Task CreateEmployeeAsync(EmployeeInputModel input)
        {
            var employee = new Employee
            {
                FullName = input.FullName,
                Email = input.Email,
                Phone = input.Phone,
                DateOfBirth = input.DateOfBirth,
                Salary = input.Salary,

            };
            this.context.Employees.Add(employee);
            await this.context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteEmployeeAsync(EmployeeInputModel input)
        {
            var employee = this.context.Employees.Where(x => x.Id == input.Id).FirstOrDefault();
            this.context.Remove(employee);
            await this.context.SaveChangesAsync();
        }

        public int GetCount()
        {
            return this.context.Employees.Count();
        }

        public EmployeeInputModel GetEmployeeById(string id)
        {
            var employee = this.context.Employees.Where(x => x.Id == id).FirstOrDefault();
            var model = new EmployeeInputModel
            {
                Id = employee.Id,
                FullName = employee.FullName,
                Email = employee.Email,
                Phone = employee.Phone,
                DateOfBirth = employee.DateOfBirth,
                Salary = employee.Salary,

            };
            return model;
        
        }

        public Dictionary<string,int> GetTop5()
        {
            Dictionary<string,int> result = new Dictionary<string, int>();

            var topEmployees = context.Tasks
                .Where(x => x.CompletedOn != null)
                .Where(x => DateTime.Compare(x.CompletedOn.Value, (DateTime.UtcNow.AddMonths(-1))) == 1)
                .Join(context.Employees, e => e.EmployeeId, emp => emp.Id, (e, emp) => new { emp.Id, emp.FullName })
                .GroupBy(t => new { t.Id, t.FullName })
                .Select(g => new { FullName = g.Key, NumTasks = g.Count() })
                .OrderByDescending(e => e.NumTasks)
                .Take(5)
                .ToList();


            foreach (var employee in topEmployees)
            {
                result[employee.FullName.FullName] = employee.NumTasks;
            }

            return result;
            

        }

        public List<Employee> GetTop5Salarys()
        {
            return this.context.Employees.OrderByDescending(x => x.Salary).Take(5).ToList();
        }

        public List<Employee> ShowAll()
        {
            return this.context.Employees.OrderByDescending(x => x.FullName).ToList();
        }

        public async System.Threading.Tasks.Task Update(EmployeeInputModel input)
        {
            var employee = this.context.Employees.Where(x => x.Id == input.Id).FirstOrDefault();

            employee.FullName = input.FullName;
            employee.Phone = input.Phone;
            employee.Email = input.Email;
            employee.Salary = input.Salary;

            this.context.Update(employee);
            await this.context.SaveChangesAsync();
        }

        public List<SelectListItem> GetDepartments()
        {
            var departments = new List<SelectListItem>();
            foreach (var department in context.Departments)
            {
                var temp = new SelectListItem { Text = department.Name, Value = department.Id.ToString() };
                departments.Add(temp);
            }
            return departments;
        }
    }
}
