using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Commands.CreateAuthor;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
{
    private readonly IAuthorRepository _authorRepository;

    public CreateAuthorCommandHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<Unit> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var newAuthor = new Author
        {
            FirstName = request.FirstName,
            LastName = request.LastName
        };
       
        await _authorRepository.CreateAuthorAsync(newAuthor);
        
        return Unit.Value;
    }
}