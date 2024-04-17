using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using GBC_Travel_Group_77.Models;
using GBC_Travel_Group_77.Areas.ProjectManagement.Models;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

namespace GBC_Travel_Group_77.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            try
            {
                base.OnModelCreating(builder);

                builder.HasDefaultSchema("Identity");

                builder.Entity<ApplicationUser>(entity =>
                {
                    entity.ToTable(name: "User");
                });

                builder.Entity<IdentityRole>(entity =>
                {
                    entity.ToTable(name: "Role");
                });

                builder.Entity<IdentityUserRole<string>>(entity =>
                {
                    entity.ToTable(name: "UserRoles");
                });

                builder.Entity<IdentityUserClaim<string>>(entity =>
                {
                    entity.ToTable(name: "UserClaims");
                });

                builder.Entity<IdentityUserLogin<string>>(entity =>
                {
                    entity.ToTable(name: "UserLogins");
                });

                builder.Entity<IdentityRoleClaim<string>>(entity =>
                {
                    entity.ToTable(name: "RoleClaims");
                });

                builder.Entity<IdentityUserToken<string>>(entity =>
                {
                    entity.ToTable(name: "UserTokens");
                });

                // builder.Entity<ApplicationUser>().HasIndex(u => u.Email).IsUnique();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: ", ex);
            }

        }
    }
}


/*
@model Car

@using Microsoft.AspNetCore.Identity
@using GBC_Travel_Group_77.Areas.ProjectManagement.Models;

@inject SignInManager<ApplicationUser> SignInManager
@inject UserManager<ApplicationUser> UserManager

@{
    var user = await UserManager.GetUserAsync(User);
    var roles = await UserManager.GetRolesAsync(user);

    if (roles.Contains("Admin"))
    {
        
    }
    else
    {
        <h1>You do not have permission for this page...</h1>
    }
}



// Serilog
            _logger.LogInformation("Calling Car Edit (GET) action");
            try
            {

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }

 */