﻿using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories
{
    public class ProductCategoryRepository : Repository<ProductCategoryEntity>
    {
        public ProductCategoryRepository(DataContext context) : base(context)
        {
        }
    }
}