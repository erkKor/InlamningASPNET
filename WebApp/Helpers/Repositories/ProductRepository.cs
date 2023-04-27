using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories
{
    public class ProductRepository : Repository<ProductEntity>
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }
    }

}
