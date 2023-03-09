using AuthenticationMicrservice.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationMicrservice.DAL.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
