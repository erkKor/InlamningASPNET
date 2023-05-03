using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ProductService _productService;


        public HomeController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
		{
			var viewModel = new HomeControllerVM 
			{ 
				BestCollection = new CardGridVM
				{
					GridItems = await _productService.GetAllProductsAsync(),
					Categories = await _productService.GetProductCategoriesAsync()
				}
			};

            return View(viewModel);
		}
	}
}
