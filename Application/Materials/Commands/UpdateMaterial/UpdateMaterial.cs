using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Material.Commands.UpdateMaterialCommand;

/// <summary>
/// Команда обновления информации о материале
/// </summary>
public class UpdateMaterial : IRequest<MaterialDto>
{
    /// <summary>
    /// Уникальный идентификатор материала
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Название материала
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Стоимость материала
    /// </summary>
    public required decimal Price { get; set; }

    /// <summary>
    /// Уникальный идентификатор продавца
    /// </summary>
    public required int SellerId { get; set; }
}

public class UpdateMaterialCommandHandler : IRequestHandler<UpdateMaterial, MaterialDto>
{
    private readonly IMaterialRepository _materialRepository;

    public UpdateMaterialCommandHandler(IMaterialRepository materialRepository)
    {
        _materialRepository = materialRepository;
    }

    public async Task<MaterialDto?> Handle(UpdateMaterial command, CancellationToken token)
    {
        MaterialDto materialDto = new MaterialDto();
        materialDto.Id = command.Id;
        materialDto.Name = command.Name;
        materialDto.Price = command.Price;
        materialDto.SellerId = command.SellerId;

        var updatedMaterial = await _materialRepository.UpdateAsync(materialDto);

        if (updatedMaterial == null)
        {
            return null;
        }

        return materialDto;
    }
}
