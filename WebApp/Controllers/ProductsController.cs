using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
			var products = await _productService.GetAllProductsAsync();
			return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
