namespace Library.Application.Commands.Book.UpdateBook;

public sealed record UpdateBookCommand(
    Guid BookId,
    string Title,
    DateTime Year,
    int Pages,
    Guid AuthorId,
    BookGenre Genre
) : IRequest<ResultResponse<Unit>>;