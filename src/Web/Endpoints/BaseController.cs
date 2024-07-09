using Microsoft.AspNetCore.Mvc;

namespace Web.Endpoints;

public abstract class BaseController : Controller
{
    protected readonly IMediator Mediator;

    protected BaseController(IMediator mediator)
    {
        Mediator = mediator;
    }
}
