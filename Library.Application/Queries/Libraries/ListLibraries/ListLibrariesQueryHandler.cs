namespace Library.Application.Queries.Libraries.ListLibraries;

public class ListLibrariesQueryHandler(LibraryContext context)
    : IRequestHandler<ListLibrariesQuery, ResultResponse<IEnumerable<ResponseLibraryUnitDto>>>
{
    public async Task<ResultResponse<IEnumerable<ResponseLibraryUnitDto>>> Handle(ListLibrariesQuery request, CancellationToken cancellationToken)
    {
        var libraries = await context.Libraries
            .Select(l => new ResponseLibraryUnitDto
                (
                    l.Name,
                    l.City,
                    l.Books.Select(b => new ResponseBookDto
                        (
                            b.Title,
                            b.Year, 
                            b.Quantity,
                            b.Pages,
                            b.Genre
                        )
                    )
                )
            )
            .ToListAsync(cancellationToken);

        return new OkResponse<IEnumerable<ResponseLibraryUnitDto>>(libraries);
    }
}