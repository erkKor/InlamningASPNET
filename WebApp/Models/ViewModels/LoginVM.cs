using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.ViewModels
{
	public class LoginVM
	{
		[Display(Name = "Email")]
		[DataType(DataType.EmailAddress)]
		[Required(ErrorMessage = "You must enter an email")]
		public string Email { get; set; } = null!;


		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "You must enter a password")]
		public string Password { get; set; } = null!;


		[Display(Name = "Remember me")]
		public bool RememberMe { get; set; } = false;

		public string ReturnUrl { get; set; } = "/";
	}
}
