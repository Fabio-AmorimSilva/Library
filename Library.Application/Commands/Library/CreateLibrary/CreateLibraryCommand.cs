using Library.Core.Result;

namespace Library.Application.Commands.Library.CreateLibrary;

public sealed record CreateLibraryCommand(string Name, string City) : IRequest<ResultResponse<Guid>>;