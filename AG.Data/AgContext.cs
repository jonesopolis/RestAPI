using AG.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace AG.Data
{
    public class AgContext : DbContext
    {
        public AgContext(DbContextOptions<AgContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseAddress> CourseAddresses { get; set; }
        public DbSet<CourseContactInfo> CourseContactInfo { get; set; }
        public DbSet<CourseTextContent> CourseTexts { get; set; }

        public DbSet<Hole> Holes { get; set; }

        public DbSet<Setting> Settings { get; set; }
    }
}
