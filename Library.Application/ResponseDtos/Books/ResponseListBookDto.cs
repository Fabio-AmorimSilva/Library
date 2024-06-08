using Library.Application.ResponseDtos.Authors;

namespace Library.Application.ResponseDtos.Books;

public readonly record struct ResponseListBookDto

{
    public required ResponseBookDto ResponseBook { get; init; }
    public required ResponseAuthorDto ResponseAuthor { get; init; }
    public required ResponseLibraryUnitDto ResponseLibrary { get; init; }
}
