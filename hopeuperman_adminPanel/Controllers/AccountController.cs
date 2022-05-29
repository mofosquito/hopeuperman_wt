//Dear anyone who sees this
//When I was doing this project
//only God and I knew how it worked.
//Now, only God knows it.

//Therefore, if you are trying to
//understand it and/or modify it
//then when it fails, please
//increase this counter for the
//next unlucky soul:

//total_hours_wasted_here = 576


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Data.Data;

namespace hopeuperman_adminPanel.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private hopeupermanDbContext _database;
        private SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,
            hopeupermanDbContext database, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _database = database;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task CreateUser()
        {
            IdentityUser user = new IdentityUser();
            user.UserName = "Admin0";
            user.Email = "admin0@email.com";
            var result = await _userManager.CreateAsync(user, "abc123");
            if (result.Succeeded)
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                //display error message
            }

        }

        public async Task Login()
        {
            await _signInManager.PasswordSignInAsync("Admin", "abc123", true, false);
        }
    }
}
