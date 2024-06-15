namespace Library.Application.ResponseDtos.Books;

public sealed record ResponseBookDto(
    string Title, 
    DateTime Year, 
    int Pages, 
    int Quantity, 
    BookGenre Genre
);