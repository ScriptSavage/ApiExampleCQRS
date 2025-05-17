using Domain.Interfaces;
using MediatR;

namespace Application.Commands.DeleteGenreFromBook;

public class DeleteGenreFromBookCommandHandler : IRequestHandler<GenreBookCommand>
{
    private readonly IBookRepository _bookRepository;

    public DeleteGenreFromBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Unit> Handle(GenreBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetBookByIdAsync(request.bookId);

        if (book is null)
        {
            throw new Exception("Book not found");
        }

        await _bookRepository.DeleteGenreFromBookAsync(request.bookId, request.genreId);

       return Unit.Value;
    }
}