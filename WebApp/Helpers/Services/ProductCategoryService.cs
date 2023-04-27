using WebApp.Helpers.Repositories;
using WebApp.Models;
using WebApp.Models.Contexts;
using WebApp.Models.Entities;
using WebApp.Models.Identity;

namespace WebApp.Helpers.Services
{
    public class ProductCategoryService
    {
        private readonly CategoryRepository _categoryRepo;
        private readonly ProductCategoriesRepository _productCategoriesRepo;

		public ProductCategoryService(CategoryRepository repository, ProductCategoriesRepository productCategoriesRepo)
		{
			_categoryRepo = repository;
			_productCategoriesRepo = productCategoriesRepo;
		}

		public async Task<CategoryEntity> GetCategoryAsync(int id)
        {
            var categoryEntity = await _categoryRepo.GetAsync(x => x.Id == id);
            return categoryEntity;
        }

        public async Task<IEnumerable<ProductCategoryModel>> GetCategoriesAsync()
        {
            var items = await _categoryRepo.GetAllAsync();
            var categories = new List<ProductCategoryModel>();

            foreach (var item in items)
                categories.Add(new ProductCategoryModel { Name = item.CategoryName, Value = item.Id });

            return categories;
        }

		public async Task AddCategoryAsync(ProductEntity product, CategoryEntity category)
		{
			await _productCategoriesRepo.AddAsync(new ProductCategoryEntity
			{
				ProductId = product.Id,
				CategoryId = category.Id
			});
		}
	}
}
