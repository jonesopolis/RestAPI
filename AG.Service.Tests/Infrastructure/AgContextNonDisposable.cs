using AG.Data;
using Microsoft.EntityFrameworkCore;

namespace AG.Service.Tests.Infrastructure
{
    public class AgContextNonDisposable : AgContext
    {
        public AgContextNonDisposable(DbContextOptions<AgContext> options) : base(options) { }

        public override void Dispose() { }
    }
}
