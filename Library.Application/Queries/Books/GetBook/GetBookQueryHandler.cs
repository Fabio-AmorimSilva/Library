namespace Library.Application.Queries.Books.GetBook;

public class GetBookQueryHandler(LibraryContext context)
    : IRequestHandler<GetBookQuery, ResultResponse<ResponseBookDto>>
{
    public async Task<ResultResponse<ResponseBookDto>> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        var book = await context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);
        if (book is null)
            return new NotFoundResponse<ResponseBookDto>(ErrorMessages.NotFound<Book>());

        return new OkResponse<ResponseBookDto>(new ResponseBookDto
        {
            Title = book.Title,
            Genre = book.Genre,
            Quantity = book.Quantity,
            Pages = book.Pages,
            Year = book.Year
        });
    }
}