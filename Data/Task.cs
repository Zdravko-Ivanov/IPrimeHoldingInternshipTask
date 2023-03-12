namespace Data
{
    public class Task
    {
        public Task()
        {
            this.IsCompleted = false;
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime? CompletedOn { get; set; }

    }
}
