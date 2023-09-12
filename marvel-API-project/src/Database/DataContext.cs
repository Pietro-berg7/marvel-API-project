using marvel_API_project.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace marvel_API_project.src.Database
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
