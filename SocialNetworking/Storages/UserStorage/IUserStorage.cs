using SocialNetworking.Models.Entities;

namespace SocialNetworking.Storages.UserStorage
{
    public interface IUserStorage
    {
        Task<User> CreateAsync(User user);
        Task<User> FindByIdAsync(int id);
    }
}