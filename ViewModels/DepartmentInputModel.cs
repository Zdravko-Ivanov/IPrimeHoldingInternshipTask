using Data;

namespace ViewModels
{
    public class DepartmentInputModel
    {
        public DepartmentInputModel()
        {
            this.Departments = new HashSet<Department>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}
