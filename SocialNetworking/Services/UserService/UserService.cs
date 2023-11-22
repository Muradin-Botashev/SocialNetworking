using SocialNetworking.Models;
using SocialNetworking.Models.Entities;
using SocialNetworking.Models.Requests;
using SocialNetworking.Storages.UserStorage;

namespace SocialNetworking.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserStorage _userStorage;
        private readonly AppSettings _appSettings;

        public UserService(IUserStorage userStorage, AppSettings appSettings)
        {
            _userStorage = userStorage;
            _appSettings = appSettings;
        }

        public async Task<RegisterResponce> RegisterAsync(RegisterRequest request)
        {
            var erer = _appSettings;
            var passwordHash = PasswordService.Hash(request.password);
            var user = new User
            {
                Age = request.age,
                Biography = request.biography,
                Birthdate = request.birthdate,
                City = request.city,
                FirstName = request.first_name,
                PasswordHash = passwordHash,
                SecondName = request.second_name,
            };
            var createdUser = await _userStorage.CreateAsync(user);
            var result = new RegisterResponce
            {
                Id = createdUser.Id
            };
            return result;
        }

        public async Task<bool> LoginAsync(LoginRequest request)
        {
            var user = await _userStorage.FindByIdAsync(request.Id);
            if (user == null)
                return false;

            var isvalidPassword = PasswordService.Verify(request.Password, user.PasswordHash);

            return isvalidPassword;
        }

        public async Task<GetUserResponce> FindByIdAsync(GetUserRequest request)
        {
            var user = await _userStorage.FindByIdAsync(request.id);
            if (user == null)
                return default;

            var result = new GetUserResponce
            {
                Id = user.Id,
                Age = user.Age,
                Biography = user.Biography,
                Birthdate = user.Birthdate,
                City = user.City,
                FirstName = user.FirstName,
                SecondName = user.SecondName
            };
            return result;
        }
    }
}