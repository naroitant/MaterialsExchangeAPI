using AutoMapper;
using Application.Common.Interfaces;

namespace Application.Common;

public abstract class BaseHandler
{
    protected readonly IAppDbContext Context;
    protected readonly IMapper Mapper;

    protected BaseHandler(IAppDbContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }
}
