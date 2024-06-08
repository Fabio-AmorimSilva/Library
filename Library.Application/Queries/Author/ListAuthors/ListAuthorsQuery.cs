using Library.Application.ResponseDtos.Authors;

namespace Library.Application.Queries.Author.ListAuthors;

public sealed record ListAuthorsQuery : IRequest<ResultResponse<IEnumerable<ResponseAuthorDto>>>;