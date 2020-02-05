using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManager.DataSeed
{
    public class Seed
    {
        public static void SeedData(UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            SeedUser(userManager);
            SeedRole(roleManager);
        }
        public static void SeedUser(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("admin@gmail.com").Result == null)
            {
                var user = new IdentityUser()
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com"
                };
                var result = userManager.CreateAsync(user, "P@word12").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }

        public static void SeedRole(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var roleName = new IdentityRole
                {
                    Name = "Administrator"
                };
                _  = roleManager.CreateAsync(roleName).Result;
            }
            if (!roleManager.RoleExistsAsync("Employee").Result)
            {
                var roleName = new IdentityRole
                {
                    Name = "Employee"
                };
                _ = roleManager.CreateAsync(roleName).Result;
            }
        }
    }
}
