namespace Library.Application.Commands.Book.UpdateBookLibrary;

public sealed record UpdateBookLibraryCommand(Guid BookId, Guid LibraryId) : IRequest<ResultResponse<Unit>>;