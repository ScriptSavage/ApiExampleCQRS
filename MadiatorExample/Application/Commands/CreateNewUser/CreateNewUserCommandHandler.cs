using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Commands.CreateNewUser;

public class CreateNewUserCommandHandler : IRequestHandler<CreateNewUserCommand>
{
    private readonly IAuthRepository _authRepository;

    public CreateNewUserCommandHandler(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public async Task<Unit> Handle(CreateNewUserCommand request, CancellationToken cancellationToken)
    {
        var newUser = new User
        {
            UserName = request.UserName,
           RoleId = request.RoleId
        };
        
        var hashedPassword = new PasswordHasher<User>()
            .HashPassword(newUser, request.Password);

        newUser.HashedPassword = hashedPassword;

      await  _authRepository.RegisterUserAsync(newUser);
      
      
      
      return Unit.Value;
    }
}