using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories
{
    public class UserAdressRepository : Repository<UserAdressEntity>
    {
        public UserAdressRepository(IdentityContext context) : base(context)
        {
        }
    }
}
