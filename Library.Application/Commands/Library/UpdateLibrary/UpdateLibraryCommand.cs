namespace Library.Application.Commands.Library.UpdateLibrary;

public sealed record UpdateLibraryCommand(
    Guid LibraryUnitId, 
    string Name, 
    string City
) : IRequest<ResultResponse<Unit>>;