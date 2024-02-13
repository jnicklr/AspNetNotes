using Microsoft.EntityFrameworkCore;
using AspNetNotes.Models;

namespace AspNetNotes.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=app.db;Cache=shared");
        }
    }
}
