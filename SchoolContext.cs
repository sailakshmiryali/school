using Microsoft.EntityFrameworkCore;
using School.Model;

namespace School
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions options)
            : base(options)
        {
            //Options = options;
        }

        public DbSet<Schools> SchoolsList { get; set; }
    }
}
