using Microsoft.EntityFrameworkCore;
using Matapi.Models;

namespace Matapi.Data
{
    public class MatApiContext : DbContext
    {
        public MatApiContext(DbContextOptions<MatApiContext> options)
            : base(options) { }

        public DbSet<Mat> Mats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mat>().HasKey(m => m.Id);
        }
    }
}
