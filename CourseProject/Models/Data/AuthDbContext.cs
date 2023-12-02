using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed Roles (User, Admin, SuperAdmin)

            var userRoleId = "4cddbfe5-0897-4685-b848-c49ace3c8614";
            var adminRoleId = "343e3c41-a9f2-45ae-8d3e-d4311a290732";
            var superAdminRoleId = "cf33c70e-779c-4505-8b0c-62e83f12babc";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                },
                new IdentityRole
                {
                  Name = "User",
                  NormalizedName = "User",
                  Id = userRoleId,
                  ConcurrencyStamp=userRoleId,
                },
                new IdentityRole
                {
                  Name = "SuperAdmin",
                  NormalizedName = "SuperAdmin",
                  Id = superAdminRoleId,
                  ConcurrencyStamp=superAdminRoleId,
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            // Seed SuperAdminUser
            var superAdminId = "23f08436-48fb-410e-af40-b17395253f7d";
            var superAdminUser = new IdentityUser
            {
                UserName = "superVanAdmin@gmail.com",
                Email = "superVanAdmin@gmail.com",
                NormalizedEmail = "superVanAdmin@gmail.com".ToUpper(),
                NormalizedUserName = "superVanAdmin@gmail.com".ToUpper(),
                Id = superAdminId,
            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superAdminUser, "Superadmin@123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

            // Add All roles to SuperAdminUser
            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminId
                }
            };

            builder.Entity<IdentityUserRole<String>>().HasData(superAdminRoles);
        }
    }
}
