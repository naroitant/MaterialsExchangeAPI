using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Mappers;
using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Material.Queries;

/// <summary>
/// Запрос на получение всех материалов
/// </summary>
public class GetAllMaterials : IRequest<List<MaterialDto>> { }

public class GetAllMaterialsQueryHandler : IRequestHandler<GetAllMaterials, List<MaterialDto>>
{
    private readonly IMaterialRepository _materialRepository;

    public GetAllMaterialsQueryHandler(IMaterialRepository materialRepository)
    {
        _materialRepository = materialRepository;
    }

    public async Task<List<MaterialDto>> Handle(GetAllMaterials request, CancellationToken token)
    {
        var materials = await _materialRepository.GetAllAsync();
        var materialDtos = materials.Select(s => s.ToMaterialDto()).ToList();
        return materialDtos;
    }
}
