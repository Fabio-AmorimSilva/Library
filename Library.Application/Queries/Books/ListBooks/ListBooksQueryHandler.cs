namespace Library.Application.Queries.Books.ListBooks;

public class ListBooksQueryHandler(LibraryContext context) : IRequestHandler<ListBooksQuery, ResultResponse<IEnumerable<ResponseListBookDto>>>
{
    public async Task<ResultResponse<IEnumerable<ResponseListBookDto>>> Handle(ListBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await context.Books
            .Select(b => new ResponseListBookDto
            (
                new ResponseBookDto
                (
                    b.Title,
                    b.Year,
                    b.Pages,
                    b.Quantity,
                    b.Genre
                ),
                new ResponseAuthorDto
                (
                    b.Author!.Name,
                    b.Author.Country,
                    b.Author.Birth
                ),
                new ResponseLibraryUnitDto
                (
                    b.Library!.Name,
                    b.Library.City,
                    b.Library.Books.Select(b => new ResponseBookDto
                        (
                            b.Title,
                            b.Year, 
                            b.Quantity,
                            b.Pages,
                            b.Genre
                        )
                    )
                )
            ))
            .ToListAsync(cancellationToken);
        
        return new OkResponse<IEnumerable<ResponseListBookDto>>(books);
    }
}