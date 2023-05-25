using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;
using WebApp.Models.Identity;

namespace WebApp.Models.ViewModels
{
	public class UserRegisterVM
	{

		[Display(Name = "First Name*")]
		[Required(ErrorMessage = "You must enter a firstname")]
        [MinLength(2, ErrorMessage = "First name must contain atleast 2 characters")]
        public string FirstName { get; set; } = null!;


		[Display(Name = "Last Name*")]
		[Required(ErrorMessage = "You must enter a lastname")]
        [MinLength(2, ErrorMessage = "Last name must contain atleast 2 characters")]
        public string LastName { get; set; } = null!;


		[Display(Name = "Street Name*")]
        [Required(ErrorMessage = "You must enter a streetname")]
        [MinLength(5, ErrorMessage = "Streetname must contain atleast 5 characters")]
        public string StreetName { get; set; } = null!;


		[Display(Name = "Postal Code*")]
		[Required(ErrorMessage = "You must enter a postal code")]
		public string PostalCode { get; set; } = null!;


		[Display(Name = "City*")]
		[Required(ErrorMessage = "You must enter a city")]
        [MinLength(2, ErrorMessage = "City must contain atleast 2 characters")]
        public string City { get; set; } = null!;


		[Display(Name = "Mobile (optional)")]
		public string? PhoneNumber { get; set; }


		[Display(Name = "Company (optional)")]
		public string? Company { get; set; }


		[Display(Name = "E-mail*")]
		[DataType(DataType.EmailAddress)]
		[Required(ErrorMessage = "You must enter an email")]
		[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You must enter a valid emailadress")]
		public string Email { get; set; } = null!;


		[Display(Name = "Password*")]
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "You must enter a password")]
		[RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "You must enter a valid password")]
		public string Password { get; set; } = null!;

		[Display(Name = "Confirm Password*")]
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "You must confirm your password")]
		public string ConfirmPassword { get; set; } = null!;

		[Display(Name = "Upload Profile Image (optional)")]
		[DataType(DataType.Upload)]
		public IFormFile? ImageFile { get; set; }

		[Display(Name = "I have read and accepts the terms and agreements")]
		[Required(ErrorMessage = "You must agree to the terms and agreements")]
		public bool TermsAndAgreement { get; set; } = false;





		public static implicit operator AppUser(UserRegisterVM model)
		{
			var entity =  new AppUser
			{
				UserName = model.Email,
				FirstName = model.FirstName,
				LastName = model.LastName,
				PhoneNumber = model.PhoneNumber,
				Email = model.Email,
				CompanyName = model.Company,
            };

			if(model.ImageFile != null )
				entity.UploadProfileImage = $"{model.Email.Replace(".", "")}_{model.ImageFile.FileName}";

			return entity;
        }


        public static implicit operator AdressEntity(UserRegisterVM model)
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
