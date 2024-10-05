namespace Library.Application.Commands.Book.UpdateBook;

public class UpdateBookCommandHandler(LibraryContext context) : IRequestHandler<UpdateBookCommand, ResultResponse<Unit>>
{
    public async Task<ResultResponse<Unit>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var author = await context.Authors
            .Include(a => a.Books)
            .FirstOrDefaultAsync(a => a.Id == request.AuthorId, cancellationToken);

        if (author is null)
            return new NotFoundResponse<Unit>(ErrorMessages.NotFound<Domain.Entities.Author>());

        var book = author.GetBook(request.BookId);

        if (book is null)
            return new NotFoundResponse<Unit>(ErrorMessages.NotFound<User>());

        var result = book.UpdateBook(
            request.Title,
            request.Year,
            request.Pages,
            request.Genre
        );

        if (result is { Success: false, Message: not null })
            return new UnprocessableResponse<Unit>(result.Message);

        await context.SaveChangesAsync(cancellationToken);

        return new NoContentResponse<Unit>();
    }
}