using AG.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using AG.SeedData;

namespace AG.Service.Tests.Infrastructure
{
    public class BaseTest
    {
        private readonly AgContextNonDisposable _context;

        public BaseTest()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<AgContext>()
                            .UseSqlite(connection)
                            .Options;

            _context = new AgContextNonDisposable(options);

            Seed.SeedContext(Context);
        }

        
        protected AgContextNonDisposable Context => _context;
    }
}
