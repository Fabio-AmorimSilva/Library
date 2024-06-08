using Library.Application.ResponseDtos.Authors;

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
        {
            Name = author.Name,
            Country = author.Country,
            Birth = author.Birth
        });
    }
}