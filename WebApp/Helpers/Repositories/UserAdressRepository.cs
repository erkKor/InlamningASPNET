using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories
{
    public class UserAdressRepository : Repository<UserAdressEntity>
    {
        public UserAdressRepository(DataContext context) : base(context)
        {
        }
    }
}
