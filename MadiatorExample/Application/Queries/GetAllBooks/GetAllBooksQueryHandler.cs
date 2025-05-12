using Domain.DTO;
using Domain.Interfaces;
using MediatR;

namespace Application.Queries.GetAllBooks;

public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
{
    private readonly IBookRepository _bookRepository;

    public GetAllBooksQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
       var data = await _bookRepository.GetAllBooksAsync();
       var bookDtos = data.Select(e => new BookDto()
       {
           PageNumbers = e.PageNumbers,
           Title = e.Title
       });
       
       return bookDtos;
    }
}