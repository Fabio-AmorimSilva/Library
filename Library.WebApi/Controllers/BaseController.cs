namespace Library.WebApi.Controllers;

public class BaseController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator Mediator = mediator;
}