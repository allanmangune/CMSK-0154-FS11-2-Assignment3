using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Assignment3
{
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
