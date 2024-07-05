using AutoMapper;
using MaterialsExchangeAPI.Application.Common.Interfaces;

namespace MaterialsExchangeAPI.Application.Common;

public abstract class BaseHandler
{
    protected readonly IAppDbContext _context;
    protected readonly IMapper _mapper;

    protected BaseHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}
