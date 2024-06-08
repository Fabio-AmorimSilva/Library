namespace Library.Application.Queries.Libraries.ListLibraries;

public class ListLibrariesQueryHandler(LibraryContext context)
    : IRequestHandler<ListLibrariesQuery, ResultResponse<IEnumerable<ResponseLibraryUnitDto>>>
{
    public async Task<ResultResponse<IEnumerable<ResponseLibraryUnitDto>>> Handle(ListLibrariesQuery request, CancellationToken cancellationToken)
    {
        var libraries = await context.Libraries
            .Select(l => new ResponseLibraryUnitDto
            {
                Name = l.Name,
                City = l.City
            })
            .ToListAsync(cancellationToken);

        return new OkResponse<IEnumerable<ResponseLibraryUnitDto>>(libraries);
    }
}