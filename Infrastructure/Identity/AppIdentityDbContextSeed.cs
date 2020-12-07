using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    DisplayName = "Fred",
                    Email = "fred@test.com",
                    UserName = "fred@test.com",
                    Address = new Address()
                    {
                        Street = "20 soliman azmt st.",
                        City = "Heliopolis",
                        State = "Cairo",
                        ZipCode = "11757"
                    }
                };
                await userManager.CreateAsync(user, "Qwerty@123");
            }
        }
    }
}
