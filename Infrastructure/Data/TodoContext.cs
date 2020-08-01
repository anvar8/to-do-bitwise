using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions options) : base (options) {

        }

        public DbSet<TodoItem> Todos {get; set;}
    }
}