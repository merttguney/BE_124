using App.Api.Data.Entitites;
using Microsoft.EntityFrameworkCore;

namespace App.Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=be124_ef_2;Trusted_Connection=True;TrustServerCertificate=Yes");
        }

    }
}
