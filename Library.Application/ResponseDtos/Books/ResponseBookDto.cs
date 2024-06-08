namespace Library.Application.ResponseDtos.Books;

public readonly record struct ResponseBookDto
{
    public required string Title { get; init; }
    public required DateTime Year { get; init; }
    public required int Pages { get; init; }
    public required int Quantity { get; init; }
    public required BookGenre Genre { get; init; }
}