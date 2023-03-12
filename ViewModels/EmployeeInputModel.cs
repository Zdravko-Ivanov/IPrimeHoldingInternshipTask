using Data;
using Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class EmployeeInputModel : IMapFrom<Employee>
    {

        public EmployeeInputModel()
        {
            //this.Departments = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            this.Employees = new HashSet<Employee>();
        }
        public string Id { get; set; }

        [Required]
        [MinLength(5)]
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"(08)[7-9][0-9]{7}", ErrorMessage = "Please enter valid phone number.")]
        public string Phone { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Range(0,100_000)]
        public decimal Salary { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public int CompletedTasks { get; set; }

    }
}
