namespace ViewModels
{
    using Data;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    public class TaskInputModel
    {
        public TaskInputModel()
        {
            this.Tasks = new HashSet<Data.Task>();
            this.Employees = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            this.DueDate = DateTime.UtcNow;
        }
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Title { get; set; }


        [Required]
        [MinLength(15)]
        public string Description { get; set; }

        public string EmployeeId { get; set; }

        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> Employees { get; set; }


        [Required]
        [Range(typeof(DateTime), "12/3/2023", "1/1/2040", ErrorMessage = "Date is out of Range")]
        public DateTime DueDate { get; set; }

        public ICollection<Data.Task> Tasks { get; set; }

        public bool IsCompleted { get; set; }

    }
}
