namespace Data
{

    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions options) :
            base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Department> Departments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
 
        }
    }
}

