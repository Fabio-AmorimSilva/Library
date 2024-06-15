namespace Library.Application.ResponseDtos.Authors;

public sealed record ResponseAuthorDto(
    string Name, 
    string Country, 
    DateTime Birth
);