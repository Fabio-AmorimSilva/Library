using Library.Application.Dtos.Library;
using Library.Core.Result;

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
        (
            library!.Name,
            library.City,
            library.Books.Select(b => new ResponseBookDto
                (
                    b.Title,
                    b.Year,
                    b.Quantity,
                    b.Pages,
                    b.Genre
                )
            )
        ));
    }
}