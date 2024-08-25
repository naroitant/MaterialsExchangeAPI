using AutoMapper;
using Application.Common.Interfaces;

namespace Application.Common;

public abstract class BaseHandler(
    IAppDbContext context,
    IMapper mapper)
{
    protected readonly IAppDbContext Context = context;
    protected readonly IMapper Mapper = mapper;
}
