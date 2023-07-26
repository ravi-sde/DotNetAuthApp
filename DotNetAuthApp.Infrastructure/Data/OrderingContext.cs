using Microsoft.EntityFrameworkCore;
using DotNetAuthApp.Core.Entities;

namespace DotNetAuthApp.Infrastructure.Data
{
    public class DotNetAuthAppContext : DbContext
    {
        public DotNetAuthAppContext(DbContextOptions<DotNetAuthAppContext> options) : base (options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
