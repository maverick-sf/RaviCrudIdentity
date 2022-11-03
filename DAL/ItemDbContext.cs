using AgainBefore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace AgainBefore.DAL
{
    public class ItemDbContext:IdentityDbContext<ApplicationUser>
    {

        public ItemDbContext(DbContextOptions<ItemDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)  
        {  
            base.OnModelCreating(builder);  
            this.SeedUsers(builder);  
            this.SeedRoles(builder);
            this.SeedUserRoles(builder);  
        }  

        private void SeedUsers(ModelBuilder builder)
        {

            ApplicationUser user = new ApplicationUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                FirstName = "Admin",
                LastName="Admin",
                Email = "admin@gmail.com",
                UserName= "admin@gmail.com",
                LockoutEnabled = false,
            };

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            //passwordHasher.HashPassword(user, "Admin*123");

            user.PasswordHash = passwordHasher.HashPassword(user, "Admin*123");

            builder.Entity<ApplicationUser>().HasData(user);
        }
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() {  UserId = "b74ddd14-6340-4840-95c2-db12554843e5", RoleId = "fab4fac1-c546-41de-aebc-a14da6895711" }
                );
        
    }

    DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
    }
}
