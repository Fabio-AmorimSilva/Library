using Library.Application.ResponseDtos.Authors;

namespace Library.Application.Queries.Author.ListAuthors;

public class ListAuthorsQueryHandler(LibraryContext context)
    : IRequestHandler<ListAuthorsQuery, ResultResponse<IEnumerable<ResponseAuthorDto>>>
{
    public async Task<ResultResponse<IEnumerable<ResponseAuthorDto>>> Handle(ListAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await context.Authors
            .Select(a => new ResponseAuthorDto
            {
                Name = a.Name,
                Country = a.Country,
                Birth = a.Birth
            })
            .ToListAsync(cancellationToken);

        return new OkResponse<IEnumerable<ResponseAuthorDto>>(authors);
    }
}