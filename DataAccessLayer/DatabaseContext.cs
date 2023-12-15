using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccessLayer
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
