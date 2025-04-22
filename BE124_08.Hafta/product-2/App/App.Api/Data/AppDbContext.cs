using App.Api.Data.Entitites;
using Microsoft.EntityFrameworkCore;

namespace App.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 

        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<SellerEntity> Sellers { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=be124_ef_2;Trusted_Connection=True;TrustServerCertificate=Yes");
        //}

    }
}
