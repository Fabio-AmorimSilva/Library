using Library.Application.ResponseDtos.Authors;

namespace Library.Application.Queries.Author.GetAuthor;

public sealed record GetAuthorQuery(Guid Id) : IRequest<ResultResponse<ResponseAuthorDto>>;