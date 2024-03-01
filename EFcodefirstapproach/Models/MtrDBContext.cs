using Microsoft.EntityFrameworkCore;

namespace EFcodefirstapproach.Models
{
    public class MtrDBContext : DbContext
    {
        public MtrDBContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Dtr> Dtrs { get; set; }
    }
}
