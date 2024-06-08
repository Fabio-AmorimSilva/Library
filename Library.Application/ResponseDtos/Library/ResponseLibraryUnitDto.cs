namespace Library.Application.ResponseDtos.Library;

public readonly record struct ResponseLibraryUnitDto
{
    public required string Name { get; init; }
    public required string City { get; init; }
    public List<ResponseBookDto> Books { get; init; }
}
