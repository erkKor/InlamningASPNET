namespace WebApp.Models.Entities
{
	public class ContactFormEntity
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string? PhoneNumber { get; set; }
		public string? CompanyName { get; set; }
		public string Message { get; set; } = null!;
	}
}
