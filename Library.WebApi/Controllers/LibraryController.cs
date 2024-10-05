namespace Library.WebApi.Controllers;

[ApiController]
[Authorize]
[ApiVersion("2.0")]
[Route("v1/library")]
public class LibraryController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var result = await Mediator.Send(new ListLibrariesQuery());
        return Ok(result);
    }

    [HttpGet("{libraryId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> GetById([FromRoute] Guid libraryId)
    {
        var result = await Mediator.Send(new GetLibraryQuery(libraryId));
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Post([FromBody] CreateLibraryCommand command)
    {
        var result = await Mediator.Send(command);
        return Created($"{result.Data}", result);
    }

    [HttpPut("{libraryId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Put(Guid libraryId, [FromBody] UpdateLibraryCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{libraryId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Delete([FromRoute] Guid libraryId)
    {
        var command = new DeleteLibraryCommand(libraryId);
        await Mediator.Send(command);
        return NoContent();
    }
}
