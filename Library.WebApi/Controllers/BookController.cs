﻿using Library.Core.Result;

namespace Library.WebApi.Controllers;

[ApiController]
[Authorize]
[ApiVersion("2.0")]
[Route("v1/books")]
public class BookController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ResultResponse<IEnumerable<Book>>>> Get()
    {
        var result = await Mediator.Send(new ListBooksQuery());
        return Ok(result);
    }

    [HttpGet("{bookId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> GetById([FromRoute] Guid bookId)
    {
        var result = await Mediator.Send(new GetBookQuery(bookId));
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<Guid>> Post([FromBody] CreateBookCommand command)
    {
        var result = await Mediator.Send(command);
        return Created($"{result}", result.Data);
    }

    [HttpPut("{bookId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult> Put(Guid bookId, [FromBody] UpdateBookCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }
    
    [HttpPut("{bookId:guid}/author/{authorId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult> UpdateBookAuthor(Guid bookId, [FromBody] UpdateBookAuthorCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }
    
    [HttpPut("{authorId:guid}/library/{libraryId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult> UpdateBookLibrary(Guid libraryId, Guid authorId, [FromBody] UpdateBookLibraryCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{authorId:guid}/books/{bookId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Delete(
        Guid bookId, 
        Guid authorId
    )
    {
        var command = new DeleteBookCommand(bookId, authorId);
        await Mediator.Send(command);
        return NoContent();
    }
}
