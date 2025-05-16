using System.Security.Claims;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Application.Commands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand,string>
{
    private readonly IAuthRepository _authRepository;
    private readonly IConfiguration _configuration;

    public LoginUserCommandHandler(IAuthRepository authRepository, IConfiguration configuration)
    {
        _authRepository = authRepository;
        _configuration = configuration;
    }

    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var doesUserExists = await _authRepository.DoesUserExistAsync(request.UserName);

        if (!doesUserExists)
        {
            throw new Exception("User does not exist");
        }

        var user = await _authRepository.GetUserByUserNameAsync(request.UserName);

        if (new PasswordHasher<User>().VerifyHashedPassword(user, user.HashedPassword, request.Password)
            == PasswordVerificationResult.Failed)
        {
            throw new Exception("Invalid User Name or password");
        }
        
        return CreateToken(user);
    }


    
    private string CreateToken(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Role, user.RoleId.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:Token"] ?? string.Empty));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var token = new JwtSecurityToken(
            issuer: _configuration["AppSettings:Issuer"],
            audience: _configuration["AppSettings:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
        
    }

}