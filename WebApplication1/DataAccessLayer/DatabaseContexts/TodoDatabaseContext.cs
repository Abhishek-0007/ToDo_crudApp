using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccessLayer.Entities;

namespace WebApplication1.DataAccessLayer.DatabaseContexts;
    public class TodoDatabaseContext : DbContext
    {
        public TodoDatabaseContext(DbContextOptions<TodoDatabaseContext> options)
        : base(options)
        {
        }

        public DbSet<TodoItemEntity> TodoItems { get; set; } = null!;
    }
