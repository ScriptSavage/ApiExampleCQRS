using Domain.DTO;
using MediatR;

namespace Application.Queries.GetBookDetails;

public class GetBookDetailsQuery : IRequest<BookDetailsDto>
{
    public int BookId { get; }

    public GetBookDetailsQuery(int bookId)
    {
        BookId = bookId;
    }
}