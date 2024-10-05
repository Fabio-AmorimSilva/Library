namespace Library.Application.Commands.Book.UpdateBookAuthor;

public sealed record UpdateBookAuthorCommand(Guid AuthorId, Guid BookId) : IRequest<ResultResponse<Unit>>;