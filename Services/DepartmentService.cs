using Data;
using ViewModels;

namespace Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext context;

        public DepartmentService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async System.Threading.Tasks.Task CreateDepartmentAsync(DepartmentInputModel input)
        {
            var deraptment = new Department
            {
                Name = input.Name,
            };
            this.context.Departments.Add(deraptment);
            await this.context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteDepartmentAsync(DepartmentInputModel input)
        {
            var department = this.context.Departments.Where(x => x.Id == input.Id).FirstOrDefault();
            this.context.Remove(department);
            await this.context.SaveChangesAsync();
        }

        public int GetCount()
        {
            return this.context.Departments.Count();
        }

        public List<Department> ShowAll()
        {
            return this.context.Departments.OrderBy(x => x.Employees.Count()).ToList();
        }
    }
}
