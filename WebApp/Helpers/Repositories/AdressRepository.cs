using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories
{
    public class AdressRepository : Repository<AdressEntity>
    {
        public AdressRepository(IdentityContext context) : base(context)
        {
        }
    }
}
