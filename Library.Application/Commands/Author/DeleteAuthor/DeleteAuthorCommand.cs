using Library.Core.Result;

namespace Library.Application.Commands.Author.DeleteAuthor;

public sealed record DeleteAuthorCommand(Guid AuthorId) : IRequest<ResultResponse<Unit>>;