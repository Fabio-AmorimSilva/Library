using Library.Application.ResponseDtos.Authors;

namespace Library.Application.Queries.Books.ListBooks;

public class ListBooksQueryHandler(LibraryContext context) : IRequestHandler<ListBooksQuery, ResultResponse<IEnumerable<ResponseListBookDto>>>
{
    public async Task<ResultResponse<IEnumerable<ResponseListBookDto>>> Handle(ListBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await context.Books
            .Select(b => new ResponseListBookDto
            {
                ResponseBook = new ResponseBookDto
                {
                    Title = b.Title,
                    Genre = b.Genre,
                    Pages = b.Pages,
                    Quantity = b.Quantity,
                    Year = b.Year
                },
                ResponseAuthor = new ResponseAuthorDto
                {
                    Name = b.Author!.Name,
                    Birth = b.Author.Birth,
                    Country = b.Author.Country
                },
                ResponseLibrary = new ResponseLibraryUnitDto
                {
                    Name = b.Library!.Name,
                    City = b.Library.City
                },
            })
            .ToListAsync(cancellationToken);
        
        return new OkResponse<IEnumerable<ResponseListBookDto>>(books);
    }
}