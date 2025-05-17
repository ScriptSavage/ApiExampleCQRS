using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Commands.AddGenreToBook;

public class AddGenreToBookCommandHandler : IRequestHandler<AddGenreToBookCommand>
{
    private readonly IBookRepository _bookRepository;
    private readonly IGenreRepository _genreRepository;

    public AddGenreToBookCommandHandler(IBookRepository bookRepository, IGenreRepository genreRepository)
    {
        _bookRepository = bookRepository;
        _genreRepository = genreRepository;
    }

    public async Task<Unit> Handle(AddGenreToBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetBookByIdAsync(request.bookId);
        
        if (book is null)
        {
            throw new Exception("Book not found");
        }
        var genre = await _genreRepository.DoesGenreExistAsync(request.genreId);

        if (!genre)
        {
            throw new Exception("Genre not found");       
        }

        var doesGenreAlreadyExists = await _genreRepository.DoesGenreExistAsync(request.genreId);

        if (!doesGenreAlreadyExists)
        {
            throw new Exception("Genre does not exists"); 
        }

        var newGenreBook = new BookGenre()
        {
            BookId = request.bookId,
            GenreId = request.genreId
        };
        
        await _bookRepository.AddGenreToBookAsync(newGenreBook);
        
        return Unit.Value;
    }
}