namespace Library.Application.ResponseDtos.Books;

public sealed record ResponseListBookDto(
    ResponseBookDto ResponseBook,
    ResponseAuthorDto ResponseAuthor,
    ResponseLibraryUnitDto ResponseLibrary
);
