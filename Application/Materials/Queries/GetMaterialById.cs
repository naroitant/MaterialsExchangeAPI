using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Mappers;
using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Material.Queries;

/// <summary>
/// Запрос на получение материала по id
/// </summary>
public class GetMaterialById : IRequest<MaterialDto>
{
    /// <summary>
    /// Уникальный идентификатор материала
    /// </summary>
    public int Id { get; set; }
}

public class GetMaterialByIdQueryHandler : IRequestHandler<GetMaterialById, MaterialDto>
{
    private readonly IMaterialRepository _materialRepository;

    public GetMaterialByIdQueryHandler(IMaterialRepository sellerRepository)
    {
        _materialRepository = sellerRepository;
    }

    public async Task<MaterialDto?> Handle(GetMaterialById request, CancellationToken token)
    {
        int id = request.Id;
        var material = await _materialRepository.GetByIdAsync(id);

        if (material == null)
        {
            return null;
        }

        var materialDto = material.ToMaterialDto();
        return materialDto;
    }
}
