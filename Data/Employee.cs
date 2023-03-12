namespace Data
{
    public class Employee
    {
        public Employee()
        {
            this.Id = Guid.NewGuid().ToString();
            CompletedTasks = 0;
        }
        public string Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime DateOfBirth { get; set; }

        public decimal Salary { get; set; }

        public int CompletedTasks { get; set; }

        public int? DepartmentId { get; set; }
    }
}
