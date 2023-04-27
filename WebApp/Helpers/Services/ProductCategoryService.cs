using WebApp.Helpers.Repositories;
using WebApp.Models;
using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Services
{
    public class ProductCategoryService
    {
        private readonly ProductCategoryRepository _repo;

        public ProductCategoryService(ProductCategoryRepository repository)
        {
            _repo = repository;
        }

        public async Task<ProductCategoryEntity> GetCategoryAsync(ProductCategoryModel model)
        {
            var categoryEntity = await _repo.GetAsync(x => x.Id == model.Value);
            return categoryEntity;
        }

        public async Task<IEnumerable<ProductCategoryModel>> GetCategoriesAsync()
        {
            var items = await _repo.GetAllAsync();
            var categories = new List<ProductCategoryModel>();

            foreach (var item in items)
                categories.Add(new ProductCategoryModel { Name = item.CategoryName, Value = item.Id });

            return categories;
        }
    }
}
