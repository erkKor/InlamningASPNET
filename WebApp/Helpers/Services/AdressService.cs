using WebApp.Helpers.Repositories;
using WebApp.Models.Entities;
using WebApp.Models.Identity;

namespace WebApp.Helpers.Services
{
    public class AdressService
    {
        private readonly AdressRepository _adressRepo;
        private readonly UserAdressRepository _userAdressRepository;


        public AdressService(AdressRepository adressRepo, UserAdressRepository userAdressRepository)
        {
            _adressRepo = adressRepo;
            _userAdressRepository = userAdressRepository;
        }

        public async Task<AdressEntity> GetOrCreateAsync(AdressEntity adressEntity)
        {
            var entity = await _adressRepo.GetAsync(x =>
            x.StreetName == adressEntity.StreetName &&
            x.PostalCode == adressEntity.PostalCode &&
            x.City == adressEntity.City 
            );

            entity ??= await _adressRepo.AddAsync(adressEntity);
            return entity!;
        }

        public async Task AddAdressAsync(AppUser user, AdressEntity adressEntity)
        {
            await _userAdressRepository.AddAsync(new UserAdressEntity
            {
                UserId = user.Id,
                AdressId = adressEntity.Id,
            });
        }
    }
}
