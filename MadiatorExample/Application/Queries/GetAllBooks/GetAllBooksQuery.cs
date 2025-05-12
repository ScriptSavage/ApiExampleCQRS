using Domain.DTO;
using MediatR;

namespace Application.Queries.GetAllBooks;

public class GetAllBooksQuery : IRequest<IEnumerable<BookDto>>;