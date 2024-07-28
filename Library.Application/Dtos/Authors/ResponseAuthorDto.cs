namespace Library.Application.Dtos.Authors;

public sealed record ResponseAuthorDto(
    string Name, 
    string Country, 
    DateTime Birth
);