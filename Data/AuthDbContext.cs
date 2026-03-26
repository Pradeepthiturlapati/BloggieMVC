using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;

namespace WebApplication1.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            var adminRoleId = "ffb36028-9f0e-47bf-96a0-952c8ff0ea93";
            var superAdminRoleId = "41efc110-e697-4d35-b1d5-b45204fd2456";
            var userRoleId = "d2c8591b-98f6-4959-9f72-398c862ba397";
            var roles = new List<IdentityRole>
             {
                 new IdentityRole
                 {
                     Name="Admin",
                     NormalizedName="Admin",
                     Id =adminRoleId,
                     ConcurrencyStamp = adminRoleId
                 },

                 new IdentityRole
                 {
                     Name = "SuperAdmin",
                     NormalizedName="SuperAdmin",
                     Id=superAdminRoleId,
                     ConcurrencyStamp=superAdminRoleId
                 },

                 new IdentityRole
                 {
                     Name = "User",
                     NormalizedName = "User",
                     Id=userRoleId,
                     ConcurrencyStamp=userRoleId
                 }

             };

            builder.Entity<IdentityRole>().HasData(roles);

            /*  var superAdminId = "0bd7ab1f-19fb-4a3e-80e0-36af36e23e73";

              var superAdminUser = new IdentityUser
              {
                  UserName = "superadmin@bloggie.com",
                  Email = "superadmin@bloggie.com",
                  NormalizedEmail = "superadmin@bloggie.com".ToUpper(),
                  NormalizedUserName = "superadmin@bloggie.com".ToUpper(),
                  Id = superAdminId,

              };

              //superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                //  .HashPassword(superAdminUser, "admin@123");


              builder.Entity<IdentityUser>().HasData(superAdminUser);

              var superAdminRoles = new List<IdentityUserRole<string>>
              {
                  new IdentityUserRole<string>
                  {
                      RoleId = adminRoleId,
                      UserId = superAdminId
                  },
                  new IdentityUserRole<string>
                  {
                      RoleId = superAdminId ,
                      UserId = superAdminId
                  },
                  new IdentityUserRole<string>
                  {
                      RoleId = userRoleId ,
                      UserId = superAdminId
                  }
              };

              builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
          }*/
        }
    }
}
