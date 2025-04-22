using App.Web.Mvc.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Mvc.Data
{
    public class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext db)
        {
            if ( await db.Users.AnyAsync()) // hiç eleman var mı?
            {
                return; // early return
            }

            var adminRole = new RoleEntity
            {
                Name = "Admin"
            };
            var moderatorRole = new RoleEntity
            {
                Name = "Moderator"
            };

            db.Roles.AddRange(adminRole, moderatorRole);

            await db.SaveChangesAsync();

            var users = new[]
            {
                new UserEntity
                {
                    Name = "Cemil",
                    Email = "cemil@cemil.com",
                    Password = "1234",
                    RoleId = moderatorRole.Id
                },
                new UserEntity
                {
                    Name = "Suat",
                    Email = "suat@suat.com",
                    Password = "1234",
                    RoleId = adminRole.Id
                },
            };

            db.Users.AddRange(users); // AddRange ile DbSet'lere toplu halde veri eklenebilir.

            await db.SaveChangesAsync();

        }
    }
}
