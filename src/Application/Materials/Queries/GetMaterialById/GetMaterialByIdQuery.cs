using AutoMapper;
using Application.Common;
using Application.Common.Interfaces;

namespace Application.Materials.Queries.GetMaterialById;

/// <summary>
/// Запрос на получение материала по id
/// </summary>
public record GetMaterialByIdQuery : IRequest<GetMaterialResponseDto?>
{
    /// <summary>
    /// Уникальный идентификатор материала
    /// </summary>
    public int Id { get; init; }
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
            Mapper.Map<GetMaterialByIdRequestDto>(request);
        var material = await Context.Materials
            .AsNoTracking()
            .FirstOrDefaultAsync(u =>
                u.Id == getMaterialByIdRequestDto.Id, token);

        if (material is null)
        {
            return null;
        }

        var getMaterialResponseDto =
            Mapper.Map<GetMaterialResponseDto>(material);
        return getMaterialResponseDto;
    }
}
