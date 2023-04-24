using Microsoft.AspNetCore.Identity;
using WebApp.Models.Entities;

namespace WebApp.Models.Identity
{
	public class AppUser : IdentityUser
	{
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string? CompanyName { get; set; }
		public string? UploadProfileImage { get; set; }

		public ICollection<UserAdressEntity> Adresses { get; set; } = new HashSet<UserAdressEntity>();

	}
}
