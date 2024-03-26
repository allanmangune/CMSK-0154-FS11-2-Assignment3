using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Assignment3
{
    /// <summary>
    /// Represents a class that deals with the creation of EF migration code.
    /// </summary>
    public class Assignment3DbContextFactory : IDesignTimeDbContextFactory<Assignment3DbContext>
    {
        public Assignment3DbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Assignment3DbContext>();
            optionsBuilder.UseSqlite("Data Source=assignment3.db"); 

            return new Assignment3DbContext(optionsBuilder.Options);
        }
    }
}
