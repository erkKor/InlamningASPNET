using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories
{
	public class ContactFormRepository : Repository<ContactFormEntity>
	{
		public ContactFormRepository(DataContext context) : base(context)
		{
		}
	}
}
