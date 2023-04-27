using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories
{
	public class ProductCategoriesRepository : Repository<ProductCategoryEntity>
	{
		public ProductCategoriesRepository(DataContext context) : base(context)
		{
		}
	}
}
