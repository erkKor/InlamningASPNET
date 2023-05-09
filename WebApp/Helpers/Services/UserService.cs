using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Helpers.Repositories;
using WebApp.Models.Entities;
using WebApp.Models.Identity;
using WebApp.Models.ViewModels;

namespace WebApp.Helpers.Services
{
    public class UserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly UserAdressRepository _userAdressRepo;
        private readonly AdressRepository _adressRepo;

		public UserService(UserManager<AppUser> userManager, UserAdressRepository userAdressRepo, AdressRepository adressRepo)
		{
			_userManager = userManager;
			_adressRepo = adressRepo;
			_userAdressRepo = userAdressRepo;
		}

        public async Task<UserVM> GetUserByEmailAsync (string email)
        {
           var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
           var userAdressId = await _userAdressRepo.GetAsync(x => x.UserId == user!.Id);
           var adress = await _adressRepo.GetAsync(x => x.Id == userAdressId.AdressId);

		   var userViewModel = new UserVM
			{
				Id = user!.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber,
                Company = user.CompanyName,
                StreetName = adress.StreetName,
                City = adress.City,
                PostalCode = adress.PostalCode,
                ImageUrl = user.UploadProfileImage
			};

            return userViewModel;
        }
    }
}
