using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly ProjectContext _context;
    private IAuthRepository _authRepositoryImplementation;

    public AuthRepository(ProjectContext context)
    {
        _context = context;
    }

    public async Task<int> RegisterUserAsync(User user)
    {
         await _context.Users.AddAsync(user);
        var commitData = await _context.SaveChangesAsync();
        return commitData;
    }

    public async Task<bool> DoesUserExistAsync(string userName)
    {
        var doesUserExists = await _context.Users.AnyAsync(e=>e.UserName == userName);
        return doesUserExists;
    }

    public async Task<User> GetUserByUserNameAsync(string userName)
    {
        var user = await _context.Users.FirstOrDefaultAsync(e=>e.UserName == userName);
        return user;
    }
}