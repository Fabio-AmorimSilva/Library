namespace Library.Application.Queries.Libraries.GetLibrary;

public class GetLibraryQueryHandler(LibraryContext context)
    : IRequestHandler<GetLibraryQuery, ResultResponse<ResponseLibraryUnitDto>>
{
    public async Task<ResultResponse<ResponseLibraryUnitDto>> Handle(GetLibraryQuery request, CancellationToken cancellationToken)
    {
        var library = await context.Libraries
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(l => l.Id == request.LibraryId, cancellationToken);

        if (library is null)
            return new NotFoundResponse<ResponseLibraryUnitDto>(ErrorMessages.NotFound<LibraryUnit>());

        return new OkResponse<ResponseLibraryUnitDto>(new ResponseLibraryUnitDto
        {
            Name = library.Name,
            City = library.City
        });
    }
}