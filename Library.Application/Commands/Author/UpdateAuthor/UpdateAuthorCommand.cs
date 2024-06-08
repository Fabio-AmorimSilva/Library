namespace Library.Application.Commands.Author.UpdateAuthor;

public sealed record UpdateAuthorCommand(
    Guid AuthorId, 
    string Name, 
    string Country, 
    DateTime Birth
) : IRequest<ResultResponse<Unit>>;