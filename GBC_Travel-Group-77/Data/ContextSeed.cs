using Microsoft.AspNetCore.Identity;
using GBC_Travel_Group_77.Areas.ProjectManagement.Models;

namespace GBC_Travel_Group_77.Data
{
    public class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            try
            {
                await roleManager.CreateAsync(new IdentityRole(Enum.Roles.Admin.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Enum.Roles.Traveller.ToString()));
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating roles: ", ex);
            }
        }

        public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            try
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@domain.ca",
                    FirstName = "Main",
                    LastName = "Admin",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                };

                // Check if the admin user does not already exist in the database.
                if (userManager.Users.All(u => u.Id != adminUser.Id))
                {
                    // Attempt to find the admin user by their email address.
                    var user = await userManager.FindByEmailAsync(adminUser.Email);

                    // If the super user does not exist, proceed with creation.
                    if (user == null)
                    {
                        // Create the admin user account with a specified password.
                        await userManager.CreateAsync(adminUser, "P@ssword12$");

                        // Assign the admin user with all the following roles
                        await userManager.AddToRoleAsync(adminUser, Enum.Roles.Admin.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating a default admin: ", ex);
            }
        }
    }
}
