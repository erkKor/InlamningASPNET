using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services;
using WebApp.Models.Identity;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Authorize]
    public class AdminController : Controller
	{
        private readonly UserManager<AppUser> _userManager;
        private readonly ProductService _productService;

		public AdminController(UserManager<AppUser> userManager, ProductService productService)
		{
			_userManager = userManager;
			_productService = productService;
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
			var products = await _productService.GetAllProductsAsync();
			return View(products);

        }

        public async Task<IActionResult> AddProduct(AddProductViewModel viewModel)
        {
            if (!await _userManager.IsInRoleAsync(await _userManager.GetUserAsync(User), "Admin"))
            {
                return RedirectToAction("Index", "Denied");
            }

            if(ModelState.IsValid)
            {
				await _productService.AddProductAsync(viewModel);
				return RedirectToAction("Index");
			}

            return View(viewModel);
        }
	}
}
