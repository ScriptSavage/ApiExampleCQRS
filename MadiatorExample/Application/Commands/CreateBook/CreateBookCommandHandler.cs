using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Commands.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand>
{
    private readonly IBookRepository _bookRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IAuthorRepository _authorRepository;

    public CreateBookCommandHandler(IBookRepository bookRepository, IGenreRepository genreRepository, IAuthorRepository authorRepository)
    {
        _bookRepository = bookRepository;
        _genreRepository = genreRepository;
        _authorRepository = authorRepository;
    }

    public async Task<Unit> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var newBook = new Book
        {
            Title = request.Title,
            PageNumbers = request.PageNumbers,
        };

       var authors = await _authorRepository.GetAllAuthorsByIdAsync(request.AuthorsId);
       var genres = await _genreRepository.GetAllGenresByIdAsync(request.GenresId);

       foreach (var i in genres)
       {
           newBook.BookGenres.Add(new BookGenre()
           {
               Book = newBook,
               Genre = i,
               GenreId = i.GenreId
           });
       }


       foreach (var i in authors)
       {
           newBook.BooksAuthors.Add(new BookAuthors()
           {
               Book = newBook,
               Author = i,
               AuthorId = i.AuthorId
           });
       }

       await _bookRepository.AddNewBookAsync(newBook);
       return Unit.Value;
    }
}