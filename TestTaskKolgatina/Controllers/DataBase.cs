using Microsoft.EntityFrameworkCore;
using TestTaskKolgatina.Models;

namespace TestTaskKolgatina.Controllers
{
    public class DataBase : DbContext
    {
        public DataBase(DbContextOptions<DataBase> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
