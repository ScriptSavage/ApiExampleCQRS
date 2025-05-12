using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Queries.GetBookDetails;

public class GetBookDetailsQueryHandler : IRequestHandler<GetBookDetailsQuery, BookDetailsDto>
{
    private readonly IBookRepository _bookRepository;

    public GetBookDetailsQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<BookDetailsDto> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
    {
        var data = await _bookRepository.GetBookDetailsAsync(request.BookId);

        var bookDetails = new BookDetailsDto
        {
            Title = data.Title,
            PageNumbers = data.PageNumbers,
            AuthorDetailsDtos = data.BooksAuthors.Select(e => new AuthorDetailsDto
            {
                FirstName = e.Author.FirstName,
                LastName = e.Author.LastName,
            }).ToList(),
            GenreDetailsDtos = data.BookGenres.Select(e=> new GenreDetailsDto
            {
                Name = e.Genre.Name
            }).ToList()
        };
        
        return bookDetails;
    }
}