using AutoMapper;
using MaterialsExchangeAPI.Application.Common;
using MaterialsExchangeAPI.Application.Common.Interfaces;

namespace MaterialsExchangeAPI.Application.Materials.Queries.GetMaterialById;

/// <summary>
/// Запрос на получение материала по id
/// </summary>
public record GetMaterialByIdQuery : IRequest<GetMaterialResponseDto?>
{
    /// <summary>
    /// Уникальный идентификатор материала
    /// </summary>
    public int Id;
}

public class GetMaterialByIdQueryHandler : BaseHandler,
    IRequestHandler<GetMaterialByIdQuery, GetMaterialResponseDto?>
{
    public GetMaterialByIdQueryHandler(IAppDbContext context, IMapper mapper)
        : base(context, mapper) { }

    public async Task<GetMaterialResponseDto?> Handle(
        GetMaterialByIdQuery request, CancellationToken token)
    {
        var getMaterialByIdRequestDto =
            _mapper.Map<GetMaterialByIdRequestDto>(request);
        var material = await _context.Materials
            .AsNoTracking()
            .FirstOrDefaultAsync(u =>
                u.Id == getMaterialByIdRequestDto.Id, token);

        if (material is null)
        {
            return null;
        }

        var getMaterialResponseDto =
            _mapper.Map<GetMaterialResponseDto>(material);
        return getMaterialResponseDto;
    }
}
