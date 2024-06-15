namespace Library.Application.ResponseDtos.Library;

public sealed record ResponseLibraryUnitDto(
    string Name,
    string City,
    IEnumerable<ResponseBookDto> Books
);

