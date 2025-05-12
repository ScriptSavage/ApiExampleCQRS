using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Commands.CreateGenre;

public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand>
{
    private readonly IGenreRepository _genreRepository;

    public CreateGenreCommandHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<Unit> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        var newGenre = new Genre()
        {
            Name = request.Name,
        };
        
       await _genreRepository.AddNewGenre(newGenre);
        return Unit.Value;
    }
}