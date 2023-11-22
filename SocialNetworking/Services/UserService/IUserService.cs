using SocialNetworking.Models.Requests;

namespace SocialNetworking.Services.UserService
{
    public interface IUserService
    {
        Task<GetUserResponce> FindByIdAsync(GetUserRequest request);
        Task<bool> LoginAsync(LoginRequest request);
        Task<RegisterResponce> RegisterAsync(RegisterRequest request);
    }
}