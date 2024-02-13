using Microsoft.EntityFrameworkCore;
using mywebAPI.models;

namespace mywebAPI.Data
{
    public class WebDbContext : DbContext
    {
        public WebDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
