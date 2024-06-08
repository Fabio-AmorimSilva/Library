namespace Library.Application.Queries.Books.GetBook;

public sealed record GetBookQuery(Guid Id) : IRequest<ResultResponse<ResponseBookDto>>;