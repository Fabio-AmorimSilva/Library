namespace Library.Application.Queries.Books.ListBooks;

public sealed record ListBooksQuery : IRequest<ResultResponse<IEnumerable<ResponseListBookDto>>>;