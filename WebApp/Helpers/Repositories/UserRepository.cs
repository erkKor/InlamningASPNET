using WebApp.Models.Contexts;
using WebApp.Models.Identity;

namespace WebApp.Helpers.Repositories
{
    public class UserRepository : Repository<AppUser>
    {
        public UserRepository(DataContext context) : base(context)
        {
        }
    }
}
