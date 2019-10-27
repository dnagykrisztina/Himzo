using Himzo.Dal.Entities;
using Himzo.Dal.SeedInterfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Himzo.Dal.SeedService
{
    public class UserSeedService : IUserSeedService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        public UserSeedService(RoleManager<Role> roleManager,
                               UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task SeedUserAsync()
        {
            if (!await _roleManager.RoleExistsAsync(Role.Admin))
                await _roleManager.CreateAsync(new Role { Name = Role.Admin });
            if (!await _roleManager.RoleExistsAsync(Role.Kortag))
                await _roleManager.CreateAsync(new Role { Name = Role.Kortag });
            if (!await _roleManager.RoleExistsAsync(Role.User))
                await _roleManager.CreateAsync(new Role { Name = Role.User });

            if ((await _userManager.GetUsersInRoleAsync(Role.Admin)).Count == 0)
            {
                var user = new User
                {
                    Email = "admin@himzo.hu",
                    Name = "Adminisztrátor",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "admin@himzo.hu",
                    Comments = new List<Comment>(),
                    Orders = new List<Order>()
                };
                var createResult = await _userManager.CreateAsync(user, "$Administrator123");
                var addToRoleResult = await _userManager.AddToRoleAsync(user, Role.Admin);
                if (!createResult.Succeeded || !addToRoleResult.Succeeded)
                    throw new ApplicationException($"Admin user cannot be created!");
            }

            if ((await _userManager.GetUsersInRoleAsync(Role.Kortag)).Count == 0)
            {
                var user = new User
                {
                    Email = "kortag@himzo.hu",
                    Name = "Kortag",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "kortag@himzo.hu",
                    Comments = new List<Comment>(),
                    Orders = new List<Order>()
                };
                var createResult = await _userManager.CreateAsync(user, "#Kortag123");
                var addToRoleResult = await _userManager.AddToRoleAsync(user, Role.Kortag);
                if (!createResult.Succeeded || !addToRoleResult.Succeeded)
                    throw new ApplicationException($"Kortag user cannot be created!");
            }

            if ((await _userManager.GetUsersInRoleAsync(Role.User)).Count == 0)
            {
                var user = new User
                {
                    Email = "testuser@himzo.hu",
                    Name = "TestUser",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "testuser@himzo.hu",
                    Comments = new List<Comment>(),
                    Orders = new List<Order>()
                };
                var createResult = await _userManager.CreateAsync(user, "$TestUser123");
                var addToRoleResult = await _userManager.AddToRoleAsync(user, Role.User);
                if (!createResult.Succeeded || !addToRoleResult.Succeeded)
                    throw new ApplicationException($"Test user cannot be created!");
            }
        }
    }
}
