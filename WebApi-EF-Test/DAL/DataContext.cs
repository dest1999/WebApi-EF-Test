using Microsoft.EntityFrameworkCore;
using WebApi_EF_Test.Models;

namespace WebApi_EF_Test.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
