namespace Library.Application.Dtos.Library;

public sealed record ResponseLibraryUnitDto(
    string Name,
    string City,
    IEnumerable<ResponseBookDto> Books
);

