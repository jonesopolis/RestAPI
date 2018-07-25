using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AG.Data.Infrastructure
{
    public class AgContextFactory : IDesignTimeDbContextFactory<AgContext>
    {
        public AgContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AgContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Golf;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new AgContext(optionsBuilder.Options);
        }
    }
}
