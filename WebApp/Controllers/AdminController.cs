﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Helpers.Services;
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

        public async Task<IActionResult> Index()
		{
			var users = await _userManager.Users.ToListAsync();
			var userViewModels = new List<UserVM>();

			foreach (var user in users)
			{
				var roleNames = await _userManager.GetRolesAsync(user);
				var userViewModel = new UserVM
				{
					Id = user.Id,
					FirstName = user.FirstName,
					LastName = user.LastName,
					Email = user.Email!,
					RoleNames = roleNames.ToList(),
					RoleName = roleNames.FirstOrDefault()!
				};

				userViewModels.Add(userViewModel);
			}

			ViewBag.Roles = _roleManager.Roles.Select(r => r.Name).ToList();
			return View(userViewModels);

        }

		[HttpPost]
		public async Task<IActionResult> UpdateUserRole(string userId, string roleName)
		{
			var user = await _userManager.FindByIdAsync(userId);
			var userRoles = await _userManager.GetRolesAsync(user!);
			// Remove the old role
			await _userManager.RemoveFromRolesAsync(user!, userRoles);

			// Add the new role
			await _userManager.AddToRoleAsync(user!, roleName);

			return RedirectToAction("Index");
		}


        public IActionResult AddProduct()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> AddProduct(AddProductVM viewModel)
        {
            if(ModelState.IsValid)
            {
				await _productService.AddProductAsync(viewModel);
				return RedirectToAction("Index");
			}

            return View(viewModel);
        }


		public IActionResult AddUser()
		{
			return View();
		}

		[HttpPost]
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