using Domain.Entities;

namespace Domain.Interfaces;

public interface IAuthRepository
{
    Task<int> RegisterUserAsync(User user);
    
    Task<bool> DoesUserExistAsync(string userName);
    
    Task<User> GetUserByUserNameAsync(string userName);
}