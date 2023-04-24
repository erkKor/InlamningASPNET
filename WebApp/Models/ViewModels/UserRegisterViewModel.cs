using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;
using WebApp.Models.Identity;

namespace WebApp.Models.ViewModels
{
	public class UserRegisterViewModel
	{

		[Display(Name = "Firstname")]
		[Required(ErrorMessage = "You must enter a firstname")]
		public string FirstName { get; set; } = null!;


		[Display(Name = "Lastname")]
		[Required(ErrorMessage = "You must enter a lastname")]
		public string LastName { get; set; } = null!;


		[Display(Name = "Streetname")]
		[Required(ErrorMessage = "You must enter a streetname")]
		public string StreetName { get; set; } = null!;


		[Display(Name = "Postal code")]
		[Required(ErrorMessage = "You must enter a postal code")]
		public string PostalCode { get; set; } = null!;


		[Display(Name = "City")]
		[Required(ErrorMessage = "You must enter a city")]
		public string City { get; set; } = null!;


		[Display(Name = "Mobile")]
		public string? PhoneNumber { get; set; }


		[Display(Name = "Company")]
		public string? Company { get; set; }


		[Display(Name = "Email")]
		[DataType(DataType.EmailAddress)]
		[Required(ErrorMessage = "You must enter an email")]
		[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You must enter a valid emailadress")]
		public string Email { get; set; } = null!;


		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "You must enter a password")]
		[RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "You must enter a valid password")]
		public string Password { get; set; } = null!;

		[Display(Name = "Confirm Password")]
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "You must confirm your password")]
		public string ConfirmPassword { get; set; } = null!;

		[Display(Name = "Upload Profile Image")]
		[DataType(DataType.Upload)]
		public IFormFile? ImageFile { get; set; }

		[Display(Name = "I have read the terms and conditions")]
		[Required(ErrorMessage = "You must agree to the terms and conditions")]
		public bool TermsAndAgreement { get; set; } = false;





		public static implicit operator AppUser(UserRegisterViewModel model)
		{
			return new AppUser
            {
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                CompanyName = model.Company,
            };
        }


        public static implicit operator AdressEntity(UserRegisterViewModel model)
		{
			return new AdressEntity
			{
				StreetName = model.StreetName,
				PostalCode = model.PostalCode,
				City = model.City,
			};
		}

    }
}
