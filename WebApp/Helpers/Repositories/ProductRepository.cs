using Microsoft.EntityFrameworkCore;
using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories
{
    public class ProductRepository : Repository<ProductEntity>
    {
		private readonly DataContext _context;
        public ProductRepository(DataContext context) : base(context)
        {
			_context = context;
        }

		public async Task<IEnumerable<ProductEntity>> GetAllWithCategoriesAsync()
		{
			return await _context.Products
				.Include(p => p.Category)
					.ThenInclude(pc => pc.Category)
				.ToListAsync();
		}
	}

}
