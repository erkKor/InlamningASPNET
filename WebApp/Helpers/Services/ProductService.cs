using System.Linq;
using WebApp.Helpers.Repositories;
using WebApp.Models.Entities;
using WebApp.Models.ViewModels;

namespace WebApp.Helpers.Services
{
    public class ProductService
    {
        private readonly ProductCategoryService _categoryService;
        private readonly ProductRepository _productRepo;
		public ProductService(ProductCategoryService categoryService, ProductRepository productRepo)
		{
			_categoryService = categoryService;
			_productRepo = productRepo;
		}

		public async Task AddProductAsync(AddProductVM viewModel)
        {
            ProductEntity product = viewModel;

			await _productRepo.AddAsync(product);
			foreach (int categoryId in viewModel.SelectedCategoryId)
			{
				var category = await _categoryService.GetCategoryAsync(categoryId);
				await _categoryService.AddCategoryAsync(product, category);
			}
		}

        public async Task<CardGridItemVM> GetProductAsync(int id)
        {
            var product = await _productRepo.GetAsync(x => x.Id == id);
            return product;
        }

		public async Task<IEnumerable<CardGridItemVM>> GetAllProductsAsync()
		{    
            var products = await _productRepo.GetAllWithCategoriesAsync();

			return products.Select(p => new CardGridItemVM
            {
                Id = p.Id.ToString(),
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Category = p.Category.Select(pc => pc.Category.CategoryName).ToArray()
            });
        }

		public async Task<IEnumerable<CardGridItemVM>> GetProductsByCategoryAsync(string category)
		{
			var products = await _productRepo.GetAllWithCategoriesAsync();
			return products.Where(p => p.Category.Any(pc => pc.Category.CategoryName == category)).Select(p => new CardGridItemVM
			{
				Id = p.Id.ToString(),
				Name = p.Name,
				Description = p.Description,
				Price = p.Price,
				Category = p.Category.Select(pc => pc.Category.CategoryName).ToArray()
			});
		}


		public async Task<IEnumerable<string>> GetProductCategoriesAsync()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return categories.Select(c => c.Name);
        }
    }
}