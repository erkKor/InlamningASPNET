using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Helpers.Services;
using WebApp.Models;
using WebApp.Models.Identity;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
	{
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ProductService _productService;
        private readonly UserService _userService;
		private readonly AuthenticationService _authService;

        public AdminController(UserManager<AppUser> userManager, ProductService productService, UserService userService, RoleManager<IdentityRole> roleManager, AuthenticationService authService)
        {
            _userManager = userManager;
            _productService = productService;
            _userService = userService;
            _roleManager = roleManager;
            _authService = authService;
        }

        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
		{
			var users = await _userManager.Users.ToListAsync();
			var userViewModels = new List<UserViewModel>();

			foreach (var user in users)
			{
				var roleNames = await _userManager.GetRolesAsync(user);

				var userViewModel = new UserViewModel
				{
					Id = user.Id,
					FirstName = user.FirstName,
					LastName = user.LastName,
					Email = user.Email!,
					RoleNames = roleNames.ToList(),
					RoleName = roleNames.FirstOrDefault()

				};

				userViewModels.Add(userViewModel);
			}

			ViewBag.Roles = _roleManager.Roles.Select(r => r.Name).ToList();

			//var products = await _productService.GetAllProductsAsync();
			//         var users = await _userService.GetAllUsersAsync();
			return View(userViewModels);

        }



		[HttpPost]
		public async Task<IActionResult> UpdateUserRole(string userId, string roleName)
		{
			var user = await _userManager.FindByIdAsync(userId);
			//var role = await _roleManager.FindByNameAsync(roleName);

			var userRoles = await _userManager.GetRolesAsync(user!);
			//if (user == null)
			//{
			//	return NotFound();
			//}

			// Remove the old role
			//var oldRoleName = user.RoleName;
			await _userManager.RemoveFromRolesAsync(user!, userRoles);

			// Add the new role
			await _userManager.AddToRoleAsync(user!, roleName);

			return RedirectToAction("Index");
		}


        public async Task<IActionResult> AddProduct(AddProductVM viewModel)
        {
            //if (!await _userManager.IsInRoleAsync(await _userManager.GetUserAsync(User), "Admin"))
            //{
            //    return RedirectToAction("Index", "Denied");
            //}

            if(ModelState.IsValid)
            {
				await _productService.AddProductAsync(viewModel);
				return RedirectToAction("Index");
			}

            return View(viewModel);
        }


        public async Task<IActionResult> AddUser(UserRegisterVM viewModel)
		{
			if (ModelState.IsValid)
			{
                if (await _authService.UserExistsAsync(x => x.Email == viewModel.Email))
                    ModelState.AddModelError("", "User with the same email adress already exists.");

                if (await _authService.RegisterUserAsync(viewModel))
                    return RedirectToAction("Index");
            }

			return View(viewModel);
		}
	}
}








// ###################
// OLD CODE FOR INDEX

//if (!User.IsInRole("Admin"))
//{
//    return RedirectToAction("AccessDenied");
//}

//var userClaims = User.Claims;

//foreach (var claim in userClaims)
//{
//    var claimType = claim.Type;
//    var claimValue = claim.Value;
//    // do something with the claim information
//}


//if (!await _userManager.IsInRoleAsync(await _userManager.GetUserAsync(User), "Admin"))
//{
//    return RedirectToAction("Index", "Denied");
//}