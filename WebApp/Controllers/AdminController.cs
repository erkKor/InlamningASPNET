using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Identity;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Authorize]
    public class AdminController : Controller
	{
        private readonly UserManager<AppUser> _userManager;

        public AdminController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
		{
            //if (!User.IsInRole("Admin"))
            //{
            //    return RedirectToAction("AccessDenied");
            //}
            if (!await _userManager.IsInRoleAsync(await _userManager.GetUserAsync(User), "Admin"))
            {
                return RedirectToAction("Index", "Denied");
            }

            return View();
        }

        public async Task<IActionResult> AddProduct(AddProductViewModel viewModel)
        {
            if (!await _userManager.IsInRoleAsync(await _userManager.GetUserAsync(User), "Admin"))
            {
                return RedirectToAction("Index", "Denied");
            }

            return View(viewModel);
        }
	}
}
