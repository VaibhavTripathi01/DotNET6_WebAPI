using EntityF_API.Entity;
using Microsoft.EntityFrameworkCore;

namespace EntityF_API.DBO
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }
    }
}
