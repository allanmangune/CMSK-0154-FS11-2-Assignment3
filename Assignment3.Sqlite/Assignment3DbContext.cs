using Microsoft.EntityFrameworkCore;

namespace Assignment3
{
    public class Assignment3DbContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        // Constructor accepting DbContextOptions
        public Assignment3DbContext(DbContextOptions<Assignment3DbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Fallback configuration if not configured via DI
                optionsBuilder.UseSqlite("Data Source=assignment3.db");
            }
        }
    }
}
