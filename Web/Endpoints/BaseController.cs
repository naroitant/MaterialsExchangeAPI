using Microsoft.AspNetCore.Mvc;

namespace MaterialsExchangeAPI.Web.Endpoints;

public class BaseController : Controller
{
    protected readonly IMediator _mediator;
    
    public BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
