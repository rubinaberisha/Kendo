using Kendo.Models;
using Microsoft.EntityFrameworkCore;

namespace Kendo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //public AppDbContext() : base(new DbContextOptions<AppDbContext>())
        //{
        //}

        public DbSet<ProductViewModel>Products { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeDirectoryModel> EmployeeDirectories { get; set; }

    }
}
