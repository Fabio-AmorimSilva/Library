using Library.Core.Result;

namespace Library.Application.Commands.Library.DeleteLibrary;

public class DeleteLibraryCommandHandler(LibraryContext context)
    : IRequestHandler<DeleteLibraryCommand, ResultResponse<Unit>>
{
    public async Task<ResultResponse<Unit>> Handle(DeleteLibraryCommand request, CancellationToken cancellationToken)
    {
        var library = await context.Libraries
            .FirstOrDefaultAsync(l => l.Id == request.LibraryUnitId, cancellationToken);

        if (library is null)
            return new NotFoundResponse<Unit>(ErrorMessages.NotFound<LibraryUnit>());

        context.Libraries.Remove(library);
        await context.SaveChangesAsync(cancellationToken);

        return new NoContentResponse<Unit>();
    }
}