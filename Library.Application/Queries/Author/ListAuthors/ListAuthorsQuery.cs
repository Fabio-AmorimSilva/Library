using Library.Core.Result;

namespace Library.Application.Queries.Author.ListAuthors;

public sealed record ListAuthorsQuery : IRequest<ResultResponse<IEnumerable<ResponseAuthorDto>>>;