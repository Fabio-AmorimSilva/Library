using Library.Core.Result;

namespace Library.Application.Commands.Library.DeleteLibrary;

public sealed record DeleteLibraryCommand(Guid LibraryUnitId) : IRequest<ResultResponse<Unit>>;