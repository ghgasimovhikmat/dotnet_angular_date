using DateVoyage.Entity;
using Microsoft.EntityFrameworkCore;

namespace DateVoyage.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
      

        public DbSet<AppUser> Users { get; set; }
        // Add other DbSets for additional entities

      
    }
}
