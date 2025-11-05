using Microsoft.EntityFrameworkCore;
using Euroskills2018.Models;

namespace Euroskills2018.Data
{
    public class EuroskillsContext : DbContext
    {
        public EuroskillsContext(DbContextOptions<EuroskillsContext> options)
            : base(options) { }

        public DbSet<Orszag> Orszagok { get; set; }
        public DbSet<Szakma> Szakmak { get; set; }
        public DbSet<Versenyzo> Versenyzok { get; set; }
    }
}
