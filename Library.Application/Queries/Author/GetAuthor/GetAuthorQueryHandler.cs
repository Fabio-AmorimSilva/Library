using Library.Core.Result;

namespace Library.Application.Queries.Author.GetAuthor;

public class GetAuthorQueryHandler(LibraryContext context) : IRequestHandler<GetAuthorQuery, ResultResponse<ResponseAuthorDto>>
{
    public async Task<ResultResponse<ResponseAuthorDto>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        var author = await context.Authors
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

        if (author is null)
            return new NotFoundResponse<ResponseAuthorDto>(ErrorMessages.NotFound<Domain.Entities.Author>());

        return new OkResponse<ResponseAuthorDto>(new ResponseAuthorDto
        (
           author.Name,
           author.Country,
           author.Birth
        ));
    }
}