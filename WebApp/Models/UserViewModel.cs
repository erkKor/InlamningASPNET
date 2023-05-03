namespace WebApp.Models
{
	public class UserViewModel
	{
		public string Id { get; set; } = null!;
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string RoleName { get; set; } = null!;
		public IList<string> RoleNames { get; set; } = null!;
	} 
}
