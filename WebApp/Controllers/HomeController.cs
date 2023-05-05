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
			var products = await _productService.GetAllProductsAsync();
			var bestCollection = products.Where(p => p.Category.Contains("New"));
			var topSellers = products.Where(p => p.Category.Contains("Popular"));

			var viewModel = new HomeControllerVM
			{
				BestCollection = new CardGridVM
				{
					//GridItems = await _productService.GetAllProductsAsync(),
					GridItems = bestCollection,
					Categories = await _productService.GetProductCategoriesAsync()
				},
				TopSellers = new CardGridVM
				{
					GridItems = topSellers,
				}
			};

            return View(viewModel);
		}
	}
}
