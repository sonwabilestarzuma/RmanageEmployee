using Microsoft.AspNetCore.Identity;
using RmanageEmployee.Data;
using RmanageEmployee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserIdentityCore.Data
{
    public class DummyData
    {
        public static async Task Initialize(ApplicationDbContext context,
                             UserManager<ApplicationUser> userManager,
                             RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

            String adminId1 = "";
            String adminId2 = "";

            // for administration role
            string role1 = "Admin";
            string desc1 = "This is the administrator role";

            // this for a user role 
            string role2 = "Member";
            string desc2 = "This is the members role";

            string password = "P@$$w0rd";

            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role1, desc1, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role2, desc2, DateTime.Now));
            }

            if (await userManager.FindByNameAsync("aa@aa.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "aa@aa.com",
                    Email = "aa@aa.com"
                 
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
                adminId1 = user.Id;
            }

            if (await userManager.FindByNameAsync("bb@bb.com") == null)
            {

                var user = new ApplicationUser
                {
                    UserName = "bb@bb.com",
                    Email = "bb@bb.com"
                   
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
                adminId2 = user.Id;
            }

            if (await userManager.FindByNameAsync("mm@mm.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "mm@mm.com",
                    Email = "mm@mm.com"
                  
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role2);
                }
            }

            if (await userManager.FindByNameAsync("dd@dd.com") == null)
            {
                var user = new ApplicationUser
                {

                    UserName = "dd@dd.com",
                    Email = "dd@dd.com"
                };
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role2);
                }
            }
        }
    }
}