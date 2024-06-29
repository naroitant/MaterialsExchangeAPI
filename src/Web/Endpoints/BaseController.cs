using Microsoft.AspNetCore.Mvc;

namespace MaterialsExchangeAPI.Web.Endpoints;

public abstract class BaseController : Controller
{
    protected readonly IMediator _mediator;

    protected BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
