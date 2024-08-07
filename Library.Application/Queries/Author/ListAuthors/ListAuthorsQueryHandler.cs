using Library.Core.Result;

namespace Library.Application.Queries.Author.ListAuthors;

public class ListAuthorsQueryHandler(LibraryContext context)
    : IRequestHandler<ListAuthorsQuery, ResultResponse<IEnumerable<ResponseAuthorDto>>>
{
    public async Task<ResultResponse<IEnumerable<ResponseAuthorDto>>> Handle(ListAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await context.Authors
            .Select(a => new ResponseAuthorDto
            (
                a.Name,
                a.Country,
                a.Birth
            ))
            .ToListAsync(cancellationToken);

        return new OkResponse<IEnumerable<ResponseAuthorDto>>(authors);
    }
}