using Microsoft.EntityFrameworkCore;
using TestTaskKolgatina.Models;

namespace TestTaskKolgatina.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options) {}
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Passport> Passports { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Passport>().ToTable("Passport");
        }
    }
}
