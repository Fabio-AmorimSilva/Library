namespace Library.Application.ResponseDtos.Authors;

public sealed record ResponseAuthorDto
{
    public required string Name { get; init; }
    public required string Country { get; init; }
    public required DateTime Birth { get; init; }
    public IEnumerable<Book>? Books { get; init; }
}
