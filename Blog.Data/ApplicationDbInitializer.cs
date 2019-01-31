using Blog.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Blog.Data
{
    public static class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            ApplicationUser admin = new ApplicationUser
            {
                Name = "Admin First",
                UserName = "admin@admin.com",
                Email = "admin@admin.com"
            };

            IdentityResult adminResult = userManager.CreateAsync(admin, "admin").Result;

            if (adminResult.Succeeded)
            {
                userManager.AddToRoleAsync(admin, "admin").Wait();
            }

            ApplicationUser user = new ApplicationUser
            {
                Name = "User First",
                UserName = "user@user.com",
                Email = "user@user.com"
            };

            IdentityResult userResult = userManager.CreateAsync(user, "user").Result;

            if (userResult.Succeeded)
            {
                userManager.AddToRoleAsync(user, "user").Wait();
            }
        }
    }
}
