using Library.Core.Result;

namespace Library.Application.Commands.Book.DeleteBook;

public sealed record DeleteBookCommand(
    Guid BookId,
    Guid AuthorId
) : IRequest<ResultResponse<Unit>>;