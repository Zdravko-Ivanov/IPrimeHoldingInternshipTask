using Data;
using System.Globalization;

namespace ViewModels
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            this.TopEmployees = new Dictionary<string, int>();
            this.TopSalarys = new HashSet<Employee>();
        }
        public int EmployeeCount { get; set; }

        public int TaskCount { get; set; }

        public int DepartmentCount { get; set; }

        public Dictionary<string,int> TopEmployees { get; set; }

        public ICollection<Employee> TopSalarys { get; set; }
    }
}
