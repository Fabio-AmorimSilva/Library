using Library.Application.Dtos.Library;

namespace Library.Application.Dtos.Books;

public sealed record ResponseListBookDto(
    ResponseBookDto ResponseBook,
    ResponseAuthorDto ResponseAuthor,
    ResponseLibraryUnitDto ResponseLibrary
);
