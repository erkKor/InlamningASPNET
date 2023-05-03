using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;
using WebApp.Models.Identity;
using WebApp.Models.ViewModels;

namespace WebApp.Helpers.Services
{
    public class AuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AdressService _adressService;
        private readonly RoleManager<IdentityRole> _roleManager;

		public AuthenticationService(UserManager<AppUser> userManager, AdressService adressService, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_adressService = adressService;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}

		public async Task<bool> UserExistsAsync(Expression<Func<AppUser, bool>> expression)
        {
            return await _userManager.Users.AnyAsync(expression);
        }
        public async Task<bool> RegisterUserAsync(UserRegisterVM model)
        {
            AppUser appUser = model;
            var roleName = "User";

            if(!await _roleManager.Roles.AnyAsync())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }

            if (!await _userManager.Users.AnyAsync())
                roleName = "Admin";


            var result = await _userManager.CreateAsync(appUser, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, roleName);
                var adressEntity = await _adressService.GetOrCreateAsync(model);
                if (adressEntity != null)
                {
                    await _adressService.AddAdressAsync(appUser, adressEntity);
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> LoginAsync(LoginVM model)
        {
            var appUpser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
            if (appUpser != null)
            {
                var result = await _signInManager.PasswordSignInAsync(appUpser, model.Password, model.RememberMe, false);


                //var result = await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Admin"));
                return result.Succeeded;
            }

            return false;
        }
    }
}
