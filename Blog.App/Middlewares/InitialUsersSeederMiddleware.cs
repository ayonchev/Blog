using Blog.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.App.Middlewares
{
    public class InitialUsersSeederMiddleware
    {
        private const string EMAIL = "admin@admin.com";
        private const string ROLE = "admin";
        private const string NAME = "Admin First";
        private const string PASSWORD = "admin";

        private readonly RequestDelegate _next;

        public InitialUsersSeederMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (roleManager.Roles.Count() == 0)
                await SeedRoles(roleManager);

            if (userManager.Users.Count() == 0 || !userManager.Users.Any(u => u.Email == EMAIL))
            {
                ApplicationUser admin = new ApplicationUser
                {
                    Name = NAME,
                    UserName = EMAIL,
                    Email = EMAIL
                };

                IdentityResult adminResult = userManager.CreateAsync(admin, "admin").Result;

                if (adminResult.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, PASSWORD).Wait();
                }
            }
            else if(userManager.GetUsersInRoleAsync(ROLE).Result.Count == 0)
            {
                var admin = userManager.Users.FirstOrDefault(u => u.Email == EMAIL);

                userManager.AddToRoleAsync(admin, ROLE).Wait();
            }

            await _next(context);
        }

        private async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("User"));
        }
    }
}
