﻿using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;
using WebApp.Models.Identity;

namespace WebApp.Models.ViewModels
{
	public class ContactFormViewModel
	{
		[Display(Name = "Name*")]
		[Required(ErrorMessage = "You must enter a name")]
		public string Name { get; set; } = null!;

		[Display(Name = "E-mail*")]
		[DataType(DataType.EmailAddress)]
		[Required(ErrorMessage = "You must enter an email")]
		public string Email { get; set; } = null!;

		[Display(Name = "Phone Number (optional)")]
		public string? PhoneNumber { get; set; }

		[Display(Name = "Company (optional)")]
		public string? CompanyName { get; set; }


		[Display(Name = "Message*")]
		[DataType(DataType.MultilineText)]
		[Required(ErrorMessage = "You must write a message")]
		public string Message { get; set; } = null!;



		public static implicit operator ContactFormEntity(ContactFormViewModel model)
		{
			return new ContactFormEntity
			{
				Name = model.Name,
				Email = model.Email,
				PhoneNumber = model.PhoneNumber,
				CompanyName = model.CompanyName,
				Message = model.Message,
			};
		}
	}
}
