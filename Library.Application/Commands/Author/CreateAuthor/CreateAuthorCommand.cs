using Library.Core.Result;

namespace Library.Application.Commands.Author.CreateAuthor;

public sealed record CreateAuthorCommand(
    string Name, 
    string Country, 
    DateTime Birth
) : IRequest<ResultResponse<Guid>>;