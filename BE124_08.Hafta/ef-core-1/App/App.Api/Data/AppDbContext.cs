
using App.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; } // Veritabanındaki Users tablosunu ifade eder.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=be124_ef_1;Trusted_Connection=True;TrustServerCertificate=Yes");
        }

    }
}
