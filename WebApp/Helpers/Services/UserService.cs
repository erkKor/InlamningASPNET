using WebApp.Helpers.Repositories;
using WebApp.Models.Entities;
using WebApp.Models.Identity;

namespace WebApp.Helpers.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
