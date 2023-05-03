﻿using WebApp.Helpers.Repositories;
using WebApp.Models.Entities;
using WebApp.Models.ViewModels;
using static System.Net.Mime.MediaTypeNames;

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

		public async Task<IEnumerable<CardGridItemVM>> GetAllProductsAsync()
		{
            var products = await _productRepo.GetAllAsync();

            return products.Select(p => new CardGridItemVM
            {
                Id = p.Id.ToString(),
                Name = p.Name,
                Description = p.Description,
                Price = p.Price
            });

        }

        public async Task<IEnumerable<string>> GetProductCategoriesAsync()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return categories.Select(c => c.Name);
        }
    }
}
