namespace Library.Application.Commands.Book.CreateBook;

public sealed record CreateBookCommand(
    string Title,
    DateTime Year,
    int Pages,
    Guid AuthorId,
    Guid LibraryId,
    BookGenre Genre
) : IRequest<ResultResponse<Guid>>;